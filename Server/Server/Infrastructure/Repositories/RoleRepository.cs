using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task<IEnumerable<Role>> GetAllRoleAsync()
    {
        return await context.Role.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await context.Role.FirstOrDefaultAsync(r => r.RoleId == id);
    }

    public async Task CreateRoleAsync(Role role)
    {
        context.Role.Add(role);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRoleAsync(Role role)
    {
        context.Role.Update(role);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(int id)
    {
        var role = await context.Role.FindAsync(id);
        if (role != null)
        {
            context.Role.Remove(role);
            await context.SaveChangesAsync();
        }
    }
}