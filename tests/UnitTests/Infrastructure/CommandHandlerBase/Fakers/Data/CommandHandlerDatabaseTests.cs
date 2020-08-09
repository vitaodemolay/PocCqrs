using System.Linq;
using System.Collections.Generic;
using Infrastructure.CommandHandlerBase.Messages;
using System;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data
{
    internal sealed class CommandHandlerDatabaseTests : ICommandHandlerDatabaseTests
    {
        private readonly IList<Message> _database;

        internal CommandHandlerDatabaseTests()
        {
            _database = new List<Message>();
        }

        public void AddMessage<T>(T message) where T : MessageBase
        {
            if (message != null)
            {
                _database.Add(new Message{
                    CorrelationId = message.MessageId,
                    MessageType = typeof(T),
                    Body = message
                });
            }
        }

        public void RemoveMessage(Guid correlationId){
            while(_database.Any(f => f.CorrelationId == correlationId)){
                _database.Remove(_database.First(f => f.CorrelationId == correlationId));
            }
        }

        public IQueryable<Message> Messages => _database.AsQueryable();  
    }
}