﻿using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await context.Customer.Include(c => c.User).ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await context.Customer.Include(c => c.User).FirstOrDefaultAsync(c => c.CusId == id);
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        context.Customer.Add(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        context.Customer.Update(customer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await context.Customer.FindAsync(id);
        if (customer != null)
        {
            context.Customer.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await context.User.FirstOrDefaultAsync(u => u.UserId == userId);
    }

}