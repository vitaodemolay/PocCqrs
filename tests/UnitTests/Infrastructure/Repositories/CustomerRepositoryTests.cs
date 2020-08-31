using Bogus;
using Bogus.DataSets;
using Domain;
using FluentAssertions;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Customer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static UnitTests.Infrastructure.Repositories.Fakers.CustomerFaker;

namespace UnitTests.Infrastructure.Repositories
{
    public class CustomerRepositoryTests
    {
        private readonly DataContext _context;

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        public CustomerRepositoryTests()
        {
            var contextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlite(CreateInMemoryDatabase()).Options;

            _context = new DataContext(contextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        [Fact]
        public async Task ShouldCreateCustomerAndAddOnDatabaseSuccessfully()
        {
            //Arrange
            const int numberOfContacts = 3;
            var customer = CreateCustomerListFakeWithContacts(numberOfContacts: numberOfContacts).First();
            var repository = new CustomerRepository(_context);

            //Act
             await repository.CreateCustomerAsync(customer);

            //Assert
            (await repository.GetCustomerByIdAsync(customer.Id)).Should()
                .NotBeNull().And
                .BeSameAs(customer).And
                .Match((f => ((Customer)f).Contacts.Count == numberOfContacts && ((Customer)f).LastOrder == null && ((Customer)f).LastUpdate == null));
        }

        [Fact]
        public async Task ShouldGetOneExistsCustomerChangePropertyNameAndUpdateOnDatabaseSuccessfully()
        {
            //Arrange
            var oldCustomer = CreateCustomerListFakeWithContacts(numberOfContacts: 3).First();
            CreateOneCustomerAndSaveThisOnDatabase(oldCustomer.Id, oldCustomer.Name, oldCustomer.Contacts, _context); 
            var customerNewName = new Faker().Person.FullName;
            var repository = new CustomerRepository(_context);

            //Act
            await repository.UpdateCustomerNameAndContactsAsync(new Customer(customerNewName, oldCustomer.Id));

            //Assert
            (await repository.GetCustomerByIdAsync(oldCustomer.Id)).Should()
                .NotBeNull().And
                .NotBeSameAs(oldCustomer).And
                .Match(f => ((Customer)f).Name == customerNewName && ((Customer)f).Contacts.Count == 0 && ((Customer) f).LastOrder == null && ((Customer)f).LastUpdate != null);
        }


        [Fact]
        public async Task ShouldGetOneExistsCustomerChangeLastOrderAndUpdateOnDatabaseSuccessfully()
        {
            //Arrange
            var oldCustomer = CreateCustomerListFakeWithContacts(numberOfContacts: 3).First();
            CreateOneCustomerAndSaveThisOnDatabase(oldCustomer.Id, oldCustomer.Name, oldCustomer.Contacts, _context);
            var repository = new CustomerRepository(_context);
            var orderDate = DateTime.Now;

            //Act
            await repository.UpdateLastOrderDate(oldCustomer.Id, orderDate);

            //Assert
            (await repository.GetCustomerByIdAsync(oldCustomer.Id)).Should()
                .NotBeNull().And
                .NotBeSameAs(oldCustomer).And
                .Match(f => ( ((Customer)f).Contacts.Count == oldCustomer.Contacts.Count && ((Customer)f).LastOrder == orderDate && ((Customer)f).LastUpdate != null));
        }

    }
}
