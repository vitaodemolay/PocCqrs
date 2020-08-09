using System;

namespace Infrastructure.CommandHandlerBase.Messages
{
    public abstract class Event : MessageBase
    {
        protected Event(Guid correlationId) : base()
        {
            CorrelationId = correlationId;
        } 

        public Guid CorrelationId { get; private set; }
    }
}