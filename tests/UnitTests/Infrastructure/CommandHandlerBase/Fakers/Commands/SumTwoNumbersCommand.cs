using Infrastructure.CommandHandlerBase.Messages;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands
{
    internal class SumTwoNumbersCommand : Command
    {
        internal SumTwoNumbersCommand(int firstValue, int secondValue)
        : base()
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        internal int FirstValue { get; private set; }
        internal int SecondValue { get; private set; }

    }
}