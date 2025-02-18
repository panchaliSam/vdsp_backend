using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeamAsync();
    Task<Team> GetTeamByIdAsync(int id);
    Task CreateTeamAsync(Team team);
    Task DeleteTeamAsync(int id);
    Task UpdateTeamAsync(Team team);
}