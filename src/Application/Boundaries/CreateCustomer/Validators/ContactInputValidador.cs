using Domain;
using FluentValidation;

namespace Application.Boundaries.CreateCustomer.Validators
{
    internal class ContactInputValidador : AbstractValidator<ContactInput>
    {
        internal ContactInputValidador()
        {
            RuleFor(contact => contact.Type).IsInEnum();
            RuleFor(contact => contact.Value)
                .NotEmpty().When(contact => contact.Type == ContactType.IM)
                .EmailAddress().When(contact => contact.Type == ContactType.Email)
                .Matches(@"(([+])(\d{2})(\s?))?(\(\d{2}\))(\s?)(9?)(\d{4})-(\d{4})").When(contact => contact.Type == ContactType.Phone)
                .MaximumLength(250);
            
        }
    }
}
