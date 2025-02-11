using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task<User?> GetUserByIdAsync(int userId);
}