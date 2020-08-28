using Domain;

namespace Application.Boundaries.CreateCustomer
{
    public class ContactInput
    {
        public ContactInput(ContactType type, string value)
        {
            Type = type;
            Value = value;
        }

        public ContactType Type { get; private set; }
        public string Value { get; private set; }
    }
}