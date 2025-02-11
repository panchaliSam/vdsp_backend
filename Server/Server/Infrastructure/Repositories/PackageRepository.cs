using Microsoft.EntityFrameworkCore;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;
using Server.InfrastructureLayer.Data;

namespace Server.InfrastructureLayer.Repositories;

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