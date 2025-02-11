using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllStaffAsync();
    Task<Staff> GetStaffByIdAsync(int id);
    Task CreateStaffAsync(StaffDto staffDto);
    Task UpdateStaffAsync(int id, StaffDto staffDto);
    Task DeleteStaffAsync(int id);
}

