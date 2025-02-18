using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;

public class PackageRepository(ApplicationDbContext context) : IPackageRepository
{
    public async Task<IEnumerable<Package>> GetAllPackagesAsync()
    {
        return await context.Package.ToListAsync();
    }

    public async Task<Package> GetPackageByIdAsync(int id)
    {
        return await context.Package.FirstOrDefaultAsync(p=>p.PackageId == id);
    }

    public async Task CreatePackageAsync(Package package)
    {
        context.Package.Add(package);
        await context.SaveChangesAsync();
    }

    public async Task UpdatePackageAsync(Package package)
    {
        context.Package.Update(package);
        await context.SaveChangesAsync();
    }

    public async Task DeletePackageAsync(int id)
    {
        var package = await context.Package.FindAsync(id);
        if (package != null)
        {
            context.Package.Remove(package);
            await context.SaveChangesAsync();
        }
    }
}