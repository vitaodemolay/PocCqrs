using System;
using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data
{
    internal class Message
    {
        internal Guid CorrelationId { get; set; }
        internal Type MessageType { get; set; }
        internal MessageBase Body { get; set; }   
    }
}