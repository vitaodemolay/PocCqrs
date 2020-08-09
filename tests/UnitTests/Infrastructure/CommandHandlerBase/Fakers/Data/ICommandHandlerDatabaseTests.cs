using System;
using System.Linq;
using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data
{
    internal interface ICommandHandlerDatabaseTests
    {
        void AddMessage<T>(T message) where T : MessageBase;
        void RemoveMessage(Guid correlationId);
        IQueryable<Message> Messages { get; }
    }
}