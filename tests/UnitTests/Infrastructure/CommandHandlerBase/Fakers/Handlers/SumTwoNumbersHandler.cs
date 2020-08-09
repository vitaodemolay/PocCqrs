using Infrastructure.CommandHandlerBase.Contracts;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Handlers
{
    internal class SumTwoNumbersHandler : IHandler<SumTwoNumbersCommand>
    {
        public void Handle(SumTwoNumbersCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}