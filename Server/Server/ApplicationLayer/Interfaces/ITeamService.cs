using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamAsync();
    Task<Team> GetTeamByIdAsync(int id);
    Task CreateTeamAsync(TeamDto teamDto);
    Task UpdateTeamAsync(int id,TeamDto teamDto);
    Task DeleteTeamAsync(int id);
}

