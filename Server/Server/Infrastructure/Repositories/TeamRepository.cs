﻿using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    public async Task<IEnumerable<Team>> GetAllTeamAsync()
    {
        return await context.Team.ToListAsync();
    }

    public async Task<Team> GetTeamByIdAsync(int id)
    {
        return await context.Team.FirstOrDefaultAsync(t=>t.TeamId == id);
    }

    public async Task CreateTeamAsync(Team team)
    {
        context.Team.Add(team);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTeamAsync(Team team)
    {
        context.Team.Update(team);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(int id)
    {
        var team = await context.Team.FindAsync(id);
        if (team != null)
        {
            context.Team.Remove(team);
            await context.SaveChangesAsync();
        }
    }
    
}