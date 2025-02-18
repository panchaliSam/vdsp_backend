using Server.Application.DTOs;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;

namespace Server.Application.Services;

public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    public async Task<IEnumerable<Team>> GetAllTeamAsync()
    {
        return await teamRepository.GetAllTeamAsync();
    }

    public async Task<Team> GetTeamByIdAsync(int id)
    {
        return await teamRepository.GetTeamByIdAsync(id);
    }

    public async Task CreateTeamAsync(TeamDto teamDto)
    {
        var team = new Team
        {
            TeamName = teamDto.TeamName,
        };

        await teamRepository.CreateTeamAsync(team);
    }

    public async Task UpdateTeamAsync(int id, TeamDto teamDto)
    {
        var team = await teamRepository.GetTeamByIdAsync(id);
        team.TeamName = teamDto.TeamName;
        await teamRepository.UpdateTeamAsync(team);
    }

    public async Task DeleteTeamAsync(int id)
    {
        await teamRepository.DeleteTeamAsync(id);
    }
}

