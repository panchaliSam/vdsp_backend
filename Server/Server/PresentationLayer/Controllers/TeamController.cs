using Microsoft.AspNetCore.Mvc;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;

namespace Server.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TeamController(ITeamService teamService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await teamService.GetAllTeamAsync();
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await teamService.GetTeamByIdAsync(id);
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamDto teamDto)
    {
        await teamService.CreateTeamAsync(teamDto);
        return CreatedAtAction(nameof(GetTeamById), new{id = teamDto.TeamName}, new{message = "Created successfully"});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, TeamDto teamDto)
    {
        await teamService.UpdateTeamAsync(id, teamDto);
        return Ok(new{message = "Updated successfully"});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        await teamService.DeleteTeamAsync(id);
        return Ok(new{message = "Deleted successfully"});
    }
}