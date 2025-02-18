using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package> GetPackageByIdAsync(int id);
    Task CreatePackageAsync(Package package);
    Task UpdatePackageAsync(Package package);
    Task DeletePackageAsync(int id);
}

