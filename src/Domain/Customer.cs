using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<Contact> _contacts;

        public Customer(string name, Guid? id = null, IList<Contact> contacts = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid();
            _contacts = !(contacts is null)? contacts.ToList() : new List<Contact>();
        }

        public Customer() {
            _contacts = new List<Contact>();
        }


        public IReadOnlyList<Contact> Contacts => _contacts.AsReadOnly();

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void AddNewContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void OverrideContactList(IEnumerable<Contact> contacts = null)
        {
            _contacts.Clear();

            if(contacts?.Any() ?? false)
                _contacts.AddRange(contacts);
        }

    }
}
