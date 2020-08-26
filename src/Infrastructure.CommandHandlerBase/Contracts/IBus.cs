using Infrastructure.CommandHandlerBase.Messages;
using System.Threading.Tasks;

namespace Infrastructure.CommandHandlerBase.Contracts
{
    public interface IBus
    {
        void RegisterHandler<M, H>() where M : MessageBase where H : class, IHandler<M>;
        Task<ISendResult> Send<T>(T command) where T : Command;
        Task Dispatch<T>(T @event) where T : Event;
    }
}