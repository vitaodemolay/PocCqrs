using Domain;

namespace Application.Boundaries.CreateCustomer
{
    public class ContactInput
    {
        public ContactType Type { get; private set; }
        public string Value { get; private set; }
    }
}