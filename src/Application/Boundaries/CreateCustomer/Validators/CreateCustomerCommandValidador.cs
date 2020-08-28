using FluentValidation;

namespace Application.Boundaries.CreateCustomer.Validators
{
    internal class CreateCustomerCommandValidador : AbstractValidator<CreateCustomerCommand>
    {
        internal CreateCustomerCommandValidador()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleForEach(customer => customer.Contacts)
                .SetValidator(new ContactInputValidador());
        }
    }
}
