using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRoleAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task CreateRoleAsync(Role role);
    Task UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(int id);
}
