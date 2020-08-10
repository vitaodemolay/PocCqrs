using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;

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

        public void Send<T>(T command) where T : Command
        {
            Invoke<T>(command);
        }

        public void Dispatch<T>(T @event) where T : Event
        {
            Invoke<T>(@event);
        }

        private void Invoke<T>(MessageBase message) where T : MessageBase
        {
            //(this.DependencyResolver.GetService<IHandler<T>>()).Handle((T)message);

            var handler = this.DependencyResolver.GetService<IHandler<T>>();
            handler.Handle((T)message);
        }
    }
}