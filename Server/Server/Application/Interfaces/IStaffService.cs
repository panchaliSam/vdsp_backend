using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllStaffAsync();
    Task<Staff> GetStaffByIdAsync(int id);
    Task CreateStaffAsync(StaffDto staffDto);
    Task UpdateStaffAsync(int id, StaffDto staffDto);
    Task DeleteStaffAsync(int id);
}

