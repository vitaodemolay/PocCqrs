using FluentAssertions;
using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Messages;
using System.Linq;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events;
using Xunit;
using static UnitTests.Infrastructure.CommandHandlerBase.DependencyInjection.CommandHandlerBaseDependencyInjection;

namespace UnitTests.Infrastructure.CommandHandlerBase
{
    public class CommandHandlerBaseTests
    {
        private readonly IBus _busObject;
        private readonly ICommandHandlerDatabaseTests _database = new CommandHandlerDatabaseTests();

        public CommandHandlerBaseTests()
        {
            _busObject = GetIBusObjectForSum(_database);
        }

        [Theory]
        [InlineData(1, 2, 3)]

        public void ShouldExecuteSumTwoNumbersCommandAndReadEventOnDatabaseWithResult(int firstValue, int secondValue, int result)
        {
            //Arrange
            var _command = new SumTwoNumbersCommand(firstValue, secondValue);

            //Act
            _busObject.Send(_command);

            //Assert
            _database.Messages.Should()
                .HaveCount(1).And
                .ContainSingle(f => f.CorrelationId == _command.MessageId && f.MessageType == typeof(CalculationResultEvent));

            ((CalculationResultEvent)_database.Messages.First().Body).IsSuccess.Should().BeTrue();
            ((CalculationResultEvent)_database.Messages.First().Body).Result.Should().Be(result);
        }
    }
}
