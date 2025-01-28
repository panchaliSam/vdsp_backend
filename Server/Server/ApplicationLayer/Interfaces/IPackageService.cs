using Server.ApplicationLayer.DTOs;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Interfaces;

public interface IPackageService
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package> GetPackageByIdAsync(int id);
    Task CreatePackageAsync(PackageDto packageDto);
    Task UpdatePackageAsync(int id, PackageDto packageDto);
    Task DeletePackageAsync(int id);
}

