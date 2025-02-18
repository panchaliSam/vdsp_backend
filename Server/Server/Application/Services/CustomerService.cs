using Server.Application.DTOs;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;

namespace Server.Application.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await customerRepository.GetAllCustomersAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await customerRepository.GetCustomerByIdAsync(id);
    }

    public async Task CreateCustomerAsync(CustomerDto customerDto)
    {
        // Validate that the provided UserId exists in the database
        var user = await customerRepository.GetUserByIdAsync(customerDto.UserId);
        if (user == null)
        {
            throw new ArgumentException("Invalid UserId provided.");
        }

        // Create the new customer with the validated UserId
        var customer = new Customer
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Phone = customerDto.Phone,
            Email = customerDto.Email,
            UserId = customerDto.UserId
        };

        await customerRepository.CreateCustomerAsync(customer);
    }


    public async Task UpdateCustomerAsync(int id, CustomerDto customerDto)
    {
        var customer = await customerRepository.GetCustomerByIdAsync(id);
        customer.FirstName = customerDto.FirstName;
        customer.LastName = customerDto.LastName;
        customer.Phone = customerDto.Phone;
        customer.Email = customerDto.Email;

        await customerRepository.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await customerRepository.DeleteCustomerAsync(id);
    }
}