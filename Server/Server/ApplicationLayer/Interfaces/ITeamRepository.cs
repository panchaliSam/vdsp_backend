using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeamAsync();
    Task<Team> GetTeamByIdAsync(int id);
    Task CreateTeamAsync(Team team);
    Task DeleteTeamAsync(int id);
    Task UpdateTeamAsync(Team team);
}