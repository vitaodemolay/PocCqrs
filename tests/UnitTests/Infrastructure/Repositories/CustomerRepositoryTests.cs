using Domain;
using FluentAssertions;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Customer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
             await repository.CreateCustomer(customer);

            //Assert
            var result = await repository.GetCustomerById(customer.Id);
            result.Should()
                .NotBeNull().And
                .BeSameAs(customer).And
                .Match((f => ((Customer)f).Contacts.Count == numberOfContacts));
        }

    }
}
