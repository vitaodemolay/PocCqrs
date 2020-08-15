using Infrastructure.CommandHandlerBase.Contracts;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Handlers
{
    internal class SumTwoNumbersCommandHandler : IHandler<SumTwoNumbersCommand>
    {
        private readonly IBus _busObject;
        const string _operationName =  "SumTwoNumbers";
        public SumTwoNumbersCommandHandler(IBus busObject)
        {
            _busObject = busObject;
        }

        public void Handle(SumTwoNumbersCommand message)
        {
            var result = message.FirstValue + message.SecondValue;

            _busObject.Dispatch(new CalculationResultEvent(result, _operationName, message.MessageId)).Wait();
        }
    }
}