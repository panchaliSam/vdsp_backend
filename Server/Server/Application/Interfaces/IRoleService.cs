using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRoleAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task CreateRoleAsync(RoleDto roleDto);
    Task UpdateRoleAsync(int id, RoleDto roleDto);
    Task DeleteRoleAsync(int id);
}