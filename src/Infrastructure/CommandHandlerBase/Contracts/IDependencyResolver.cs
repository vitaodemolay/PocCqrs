using System;

namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface IDependencyResolver
    {
        T Get<T>();
        object Get(Type type);
    }
}