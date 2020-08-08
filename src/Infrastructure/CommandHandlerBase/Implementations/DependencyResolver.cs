using System;
using Infrastructure.CommandHandlerBase.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CommandHandlerBase.Implementations
{
    public sealed class DependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider; 
        public DependencyResolver(IServiceCollection services)
        {
            _serviceProvider = services.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public object Get(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}