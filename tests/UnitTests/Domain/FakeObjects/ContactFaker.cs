using Bogus;
using Domain;
using System.Collections.Generic;

namespace UnitTests.Domain.FakeObjects
{
    internal static class ContactFaker
    {
        internal static List<Contact> GetContactsFake(int numberOf)
        {
            var contactsFaker = new Faker<Contact>()
                                        .StrictMode(false)
                                        .CustomInstantiator(f=> {
                                            var type = f.PickRandom<ContactType>();
                                            var value = string.Empty;
                                            switch (type)
                                            {
                                                case ContactType.Email: 
                                                    value = f.Person.Email;
                                                    break;
                                                case ContactType.Phone: 
                                                case ContactType.IM:
                                                    value = f.Person.Phone;
                                                    break;
                                            }

                                            return new Contact(type, value);
                                         });

            return contactsFaker.Generate(numberOf);
        }
    }
}
