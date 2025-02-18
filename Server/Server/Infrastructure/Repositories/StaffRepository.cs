using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class StaffRepository(ApplicationDbContext context) : IStaffRepository
{
    public async Task<IEnumerable<Staff>> GetAllStaffAsync()
    {
        return await context.Staff
            .Include(s => s.User) 
            .Include(s => s.Role)       
            .Include(s => s.Team)      
            .ToListAsync();
    }

    public async Task<Staff> GetStaffByIdAsync(int id)
    {
                return await context.Staff
                    .Include(s => s.User) 
                    .Include(s => s.Role)       
                    .Include(s => s.Team).FirstOrDefaultAsync(s => s.StaffId == id);
    }

    public async Task CreateStaffAsync(Staff staff)
    {
        context.Staff.Add(staff);
        await context.SaveChangesAsync();
    }

    public async Task UpdateStaffAsync(Staff staff)
    {
        context.Staff.Update(staff);
        await context.SaveChangesAsync();
    }

    public async Task DeleteStaffAsync(int id)
    {
        var staff = await context.Staff.FindAsync(id);
        if (staff != null)
        {
            context.Staff.Remove(staff);
            await context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await context.User.FirstOrDefaultAsync(u=>u.UserId == id);
    }
}