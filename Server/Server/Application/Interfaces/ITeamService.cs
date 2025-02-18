using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamAsync();
    Task<Team> GetTeamByIdAsync(int id);
    Task CreateTeamAsync(TeamDto teamDto);
    Task UpdateTeamAsync(int id,TeamDto teamDto);
    Task DeleteTeamAsync(int id);
}

