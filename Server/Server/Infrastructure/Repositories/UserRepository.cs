using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<bool> AddUserAsync(string email, string userToken)
    {
        var user = new User
        {
            Email = email,
            UserToken = userToken
        };

        await context.User.AddAsync(user);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> IsUserExistsAsync(string email)
    {
        return await context.User.AnyAsync(u => u.Email == email);
    }
}