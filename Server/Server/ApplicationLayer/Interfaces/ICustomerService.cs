using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task CreateCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(int id, CustomerDto customerDto);
    Task DeleteCustomerAsync(int id);
}