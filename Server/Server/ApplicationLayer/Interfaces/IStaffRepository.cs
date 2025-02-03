using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface IStaffRepository
{
    Task<IEnumerable<Staff>> GetAllStaffAsync();
    Task<Staff> GetStaffByIdAsync(int id);
    Task CreateStaffAsync(Staff staff);
    Task UpdateStaffAsync(Staff staff);
    Task DeleteStaffAsync(int id);
    Task<User?> GetUserByIdAsync(int id);
}