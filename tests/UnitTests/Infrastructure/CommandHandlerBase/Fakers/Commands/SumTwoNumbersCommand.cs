using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Implementations;
using Infrastructure.CommandHandlerBase.Messages;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands.Validators;

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

        public override IValidationResult Validate()
        {
            var validatorResult = new SumTwoNumbersCommandValidator().Validate(this);
            if (validatorResult.IsValid)
                return CreateValidationResultForSuccess();

            return CreateValidaTionResultForFail(validatorResult.Errors.Select(f => f.ErrorMessage));
        }


        private IValidationResult CreateValidationResultForSuccess()
        {
            return new ValidationResult();
        }

        private IValidationResult CreateValidaTionResultForFail(IEnumerable<string> errors)
        {
            return new ValidationResult(errors.ToArray());
        }
    }
}