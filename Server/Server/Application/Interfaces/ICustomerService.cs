using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task CreateCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(int id, CustomerDto customerDto);
    Task DeleteCustomerAsync(int id);
}