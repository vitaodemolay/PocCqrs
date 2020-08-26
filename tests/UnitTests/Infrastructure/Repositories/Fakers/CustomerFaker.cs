using Bogus;
using Domain;
using Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using static UnitTests.Domain.FakeObjects.ContactFaker;

namespace UnitTests.Infrastructure.Repositories.Fakers
{
    internal static class CustomerFaker
    {
        internal static IList<Customer> CreateCustomerListFakeWithoutContacts(int numberOf = 1)
        {
            var customerFaker = new Faker<Customer>()
                                    .StrictMode(false)
                                    .CustomInstantiator(f => {

                                        return new Customer(f.Person.FullName);
                                    });

            return customerFaker.Generate(numberOf);
        }

        internal static IList<Customer> CreateCustomerListFakeWithContacts(int numberOf = 1, int numberOfContacts = 1)
        {
            var customerFaker = new Faker<Customer>()
                                    .StrictMode(false)
                                    .CustomInstantiator(f => {
                                        var contacts = GetContactsFake(numberOfContacts);
                                        return new Customer(f.Person.FullName, contacts: contacts);
                                    });

            return customerFaker.Generate(numberOf);
        }

        internal static void CreateOneCustomerAndSaveThisOnDatabase(Guid customerId, string customerName, IEnumerable<Contact> contacts,  DataContext context)
        {
            var customer = new Customer(customerName, customerId, contacts.ToList());

            context.Customers.Add(customer).Context.SaveChanges();
        }
    }
}
