using Server.Application.DTOs;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;

namespace Server.Application.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<IEnumerable<Role>> GetAllRoleAsync()
    {
        return await roleRepository.GetAllRoleAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await roleRepository.GetRoleByIdAsync(id);
    }

    public async Task CreateRoleAsync(RoleDto roleDto)
    {
        var role = new Role
        {
            RoleName = roleDto.RoleName,
        };
        
        await roleRepository.CreateRoleAsync(role);
        
    }

    public async Task UpdateRoleAsync(int id, RoleDto roleDto)
    {
        var role = await roleRepository.GetRoleByIdAsync(id);
        role.RoleName = roleDto.RoleName;
        
        await roleRepository.UpdateRoleAsync(role);
    }

    public async Task DeleteRoleAsync(int id)
    {
        await roleRepository.DeleteRoleAsync(id);
    }
}

