using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(Guid customerId);
    }
}
