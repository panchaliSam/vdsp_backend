using Server.Application.DTOs;
using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;

public interface IPackageService
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package> GetPackageByIdAsync(int id);
    Task CreatePackageAsync(PackageDto packageDto);
    Task UpdatePackageAsync(int id, PackageDto packageDto);
    Task DeletePackageAsync(int id);
}

