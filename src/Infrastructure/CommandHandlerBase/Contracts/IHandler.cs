using Infrastructure.CommandHandlerBase.Messages;

namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface IHandler<T> where T : MessageBase
    {
        void Handle(T @message);
    }
}