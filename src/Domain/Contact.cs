namespace Domain
{
    public class Contact
    {
        public ContactType Type { get; private set; }
        public string Value { get; private set; }

        public Contact(ContactType type, string value)
        {
            Type = type;
            Value = value;
        }

        public Contact() { }
    }
}
