using System;
using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data
{
    internal class Message
    {
        public Guid CorrelationId { get; set; }
        public Type MessageType { get; set; }
        public MessageBase Body { get; set; }   
    }
}