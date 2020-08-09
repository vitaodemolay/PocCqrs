using Infrastructure.CommandHandlerBase.Contracts;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Handlers
{
    internal class CalculationResultEventHandler : IHandler<CalculationResultEvent>
    {
        private readonly ICommandHandlerDatabaseTests _database;

        public CalculationResultEventHandler(ICommandHandlerDatabaseTests database)
        {
            _database = database;
        }

        public void Handle(CalculationResultEvent message)
        {
            _database.AddMessage(message);
        }
    }
}