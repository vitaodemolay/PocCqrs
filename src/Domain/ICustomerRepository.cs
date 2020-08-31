using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerNameAndContactsAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task UpdateLastOrderDate(Guid customerId, DateTime lastOrder);
    }
}
