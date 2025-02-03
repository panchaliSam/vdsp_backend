using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Services;

public class StaffService(IStaffRepository staffRepository) : IStaffService
{
    public async Task<IEnumerable<Staff>> GetAllStaffAsync()
    {
        return await staffRepository.GetAllStaffAsync();
    }

    public async Task<Staff> GetStaffByIdAsync(int id)
    {
        return await staffRepository.GetStaffByIdAsync(id);
    }

    public async Task CreateStaffAsync(StaffDto staffDto)
    {
        //Validate that the provided UserId exists in the database
        var user = await staffRepository.GetUserByIdAsync(staffDto.UserId);
        if (user == null)
        {
            throw new ApplicationException("Invalid UserId provided.");
        }
        
        //Create the new staff with the validated UserId
        var staff = new Staff
        {
            StaffFirstName = staffDto.StaffFirstName,
            StaffLastName = staffDto.StaffLastName,
            RoleId = staffDto.RoleId,
            UserId = staffDto.UserId,
            TeamId = staffDto.TeamId
        };
        
        await staffRepository.CreateStaffAsync(staff);
    }

    public async Task UpdateStaffAsync(int id, StaffDto staffDto)
    {
        var staff = await staffRepository.GetStaffByIdAsync(id);
        staff.StaffFirstName = staffDto.StaffFirstName;
        staff.StaffLastName = staffDto.StaffLastName;
        staff.RoleId = staffDto.RoleId;
        staff.TeamId = staffDto.TeamId;
        
        await staffRepository.UpdateStaffAsync(staff);
    }

    public async Task DeleteStaffAsync(int id)
    {
        await staffRepository.DeleteStaffAsync(id);
    }
}
