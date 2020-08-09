using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands
{
    internal class SumTwoNumbersCommand : Command
    {
        public SumTwoNumbersCommand(int firstValue, int secondValue)
        : base()
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        public int FirstValue { get; private set; }
        public int SecondValue { get; private set; }

    }
}