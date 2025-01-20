using Server.Models.DTOs;
using Server.Models.Entities;

namespace Server.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task CreateCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(int id, CustomerDto customerDto);
    Task DeleteCustomerAsync(int id);
}