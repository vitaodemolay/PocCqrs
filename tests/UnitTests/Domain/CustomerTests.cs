using Bogus;
using Domain;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using static UnitTests.Domain.FakeObjects.ContactFaker;

namespace UnitTests.Domain
{
    public class CustomerTests
    {

        [Fact]
        public void ShouldCreateNewCustomerWithoutContact()
        {
            //Arrange
            var faker = new Faker();
            var customerId = Guid.NewGuid();
            var customerName = faker.Person.FullName;

            //Act
            var customer = new Customer(customerName, customerId);

            //Assert
            customer.Should()
                .NotBeNull().And
                .Match((Customer c) => c.Name == customerName && c.Id == customerId);

            customer.Contacts.Should().BeEmpty();
        }


        [Fact]
        public void ShouldCrateNewCustomerWithAnyContact()
        {
            //Arrange
            const int numberOfContacts = 10;
            var faker = new Faker();
            var customerId = Guid.NewGuid();
            var customerName = faker.Person.FullName;
            var customerContacts = GetContactsFake(numberOfContacts);

            //Act
            var customer = new Customer(customerName, customerId, customerContacts);

            //Assert
            customer.Should()
                .NotBeNull().And
                .Match((Customer c) => c.Name == customerName && c.Id == customerId);

            customer.Contacts.Should()
                .NotBeEmpty().And
                .HaveCount(numberOfContacts).And
                .Contain(customerContacts);  
        }


        [Fact]
        public void ShouldCreateNewCustomerWithoutContactAndAddNewContact()
        {
            //Arrange
            const int numberOfContacts = 1;
            var faker = new Faker();
            var customerId = Guid.NewGuid();
            var customerName = faker.Person.FullName;
            var customerContacts = GetContactsFake(numberOfContacts);

            //Act
            var customer = new Customer(customerName, customerId);
            customer.AddNewContact(customerContacts.First());

            //Assert
            customer.Should()
                .NotBeNull().And
                .Match((Customer c) => c.Name == customerName && c.Id == customerId);

            customer.Contacts.Should()
                .NotBeEmpty().And
                .HaveCount(numberOfContacts).And
                .Contain(customerContacts);
        }
    }
}
