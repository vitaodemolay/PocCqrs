using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Infrastructure.CommandHandlerBase.Implementations
{
    public sealed class InMemoryBus:  IBus
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _container;

        private IServiceProvider DependencyResolver
        {
            get
            {
                if (_container == null)
                    _container = _services.BuildServiceProvider();

                return _container;
            }

        }

        public InMemoryBus(IServiceCollection services)
        {
            _services = services;
        }

        public void RegisterHandler<M, H>()
            where M : MessageBase
            where H : class, IHandler<M>
        {
            _services.AddTransient<IHandler<M>, H>();
        }

        public async Task<ISendResult> Send<T>(T command) where T : Command
        {
            var validationResult = command.Validate();
            if (validationResult.IsValid)
            {
               await Invoke<T>(command);
            }

            return new SendResult(validationResult);
        }

        public Task Dispatch<T>(T @event) where T : Event
        {
            return Invoke<T>(@event);
        }

        private Task Invoke<T>(MessageBase message) where T : MessageBase
        {
           return Task.Run(() => (this.DependencyResolver.GetService<IHandler<T>>()).Handle((T)message));
        }
    }
}