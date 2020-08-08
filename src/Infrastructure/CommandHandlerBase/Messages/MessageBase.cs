using System;
namespace Infrastructure.CommandHandlerBase.Messages
{
    public abstract class MessageBase
    {
        public Guid MessageId { get; private set; }

        public MessageBase(){
            MessageId = Guid.NewGuid();
        }
    }
}