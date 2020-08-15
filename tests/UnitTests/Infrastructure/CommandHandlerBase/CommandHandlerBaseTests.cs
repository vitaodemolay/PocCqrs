using FluentAssertions;
using Infrastructure.CommandHandlerBase.Contracts;
using System.Linq;
using System.Threading.Tasks;
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
        [InlineData(4, 5, 9)]
        [InlineData(6, 7, 13)]

        public async Task ShouldExecuteSumTwoNumbersCommandAndReadEventOnDatabaseWithResult(int firstValue, int secondValue, int result)
        {
            //Arrange
            var _command = new SumTwoNumbersCommand(firstValue, secondValue);

            //Act
            var sendResult = await _busObject.Send(_command);

            //Assert
            sendResult.IsSuccess.Should().BeTrue();

            _database.Messages.Should()
                .HaveCount(1).And
                .ContainSingle(f => f.CorrelationId == _command.MessageId && f.MessageType == typeof(CalculationResultEvent));

            ((CalculationResultEvent)_database.Messages.First().Body).IsSuccess.Should().BeTrue();
            ((CalculationResultEvent)_database.Messages.First().Body).Result.Should().Be(result);
        }


        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, -5)]
        [InlineData(-6, 0)]
        public async Task ShouldExecuteSumTwoNumbersCommandWithInvalidCommand(int firstValue, int secondValue)
        {
            //Arrange
            var _command = new SumTwoNumbersCommand(firstValue, secondValue);

            //Act
            var sendResult = await _busObject.Send(_command);

            //Assert
            sendResult.IsSuccess.Should().BeFalse();
            sendResult.Errors.Should().Contain("Command is not Valid");

            _database.Messages.Should().BeEmpty();
        }
    }
}
