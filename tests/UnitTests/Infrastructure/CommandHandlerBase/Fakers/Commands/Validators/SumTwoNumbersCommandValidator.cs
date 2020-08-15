using FluentValidation;

namespace UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands.Validators
{
    internal class SumTwoNumbersCommandValidator : AbstractValidator<SumTwoNumbersCommand>
    {
        internal SumTwoNumbersCommandValidator()
        {
            RuleFor(command => command.FirstValue).GreaterThan(0);
            RuleFor(command => command.SecondValue).GreaterThan(0);
        }
    }
}
