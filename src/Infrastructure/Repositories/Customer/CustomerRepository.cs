using Domain;
using Infrastructure.Database.Context;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(Domain.Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Customer> GetCustomerById(Guid customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task UpdateCustomer(Domain.Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
