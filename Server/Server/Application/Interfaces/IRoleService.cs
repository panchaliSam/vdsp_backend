using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRoleAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task CreateRoleAsync(RoleDto roleDto);
    Task UpdateRoleAsync(int id, RoleDto roleDto);
    Task DeleteRoleAsync(int id);
}