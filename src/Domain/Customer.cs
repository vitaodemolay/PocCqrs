using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public DateTime? LastOrder { get; private set; }

        private readonly List<Contact> _contacts;

        public Customer(string name, Guid? id = null, IList<Contact> contacts = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid();
            CreationDate = DateTime.Now;
            _contacts = !(contacts is null)? contacts.ToList() : new List<Contact>();
        }

        public Customer() {
            _contacts = new List<Contact>();
        }


        public void SetValueForLastUpdate(DateTime? lastUpdate = null)
        {
            if (lastUpdate is null) 
                lastUpdate = DateTime.Now;

            LastUpdate = lastUpdate;
        }


        public void SetValueForLastOrder(DateTime? lastOrder = null)
        {
            if (lastOrder is null)
                lastOrder = DateTime.Now;

            LastOrder = lastOrder;
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
