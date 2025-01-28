using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package> GetPackageByIdAsync(int id);
    Task CreatePackageAsync(Package package);
    Task UpdatePackageAsync(Package package);
    Task DeletePackageAsync(int id);
}

