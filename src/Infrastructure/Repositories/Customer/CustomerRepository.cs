﻿using Domain;
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

        public async Task CreateCustomerAsync(Domain.Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task UpdateCustomerNameAndContactsAsync(Domain.Customer customer)
        {
            var oldCustomer = await GetCustomerByIdAsync(customer.Id);

            oldCustomer.ChangeName(customer.Name);
            oldCustomer.OverrideContactList(customer.Contacts);
            oldCustomer.SetValueForLastUpdate();

            _context.Customers.Update(oldCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLastOrderDate(Guid customerId, DateTime lastOrder)
        {
            var oldCustomer = await GetCustomerByIdAsync(customerId);

            oldCustomer.SetValueForLastOrder(lastOrder);
            oldCustomer.SetValueForLastUpdate();

            _context.Customers.Update(oldCustomer);
            await _context.SaveChangesAsync();
        }
    }
}
