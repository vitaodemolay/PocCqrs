using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
    }
}
