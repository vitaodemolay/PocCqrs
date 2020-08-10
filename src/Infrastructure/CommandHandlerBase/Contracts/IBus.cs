using Infrastructure.CommandHandlerBase.Messages;

namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface IBus
    {
        void RegisterHandler<M, H>() where M : MessageBase where H : class, IHandler<M>;
        void Send<T>(T command) where T : Command;
        void Dispatch<T>(T @event) where T : Event;
    }
}