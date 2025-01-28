using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;

namespace Server.ApplicationLayer.Services;

public class PackageService(IPackageRepository packageRepository) : IPackageService
{
    public async Task<IEnumerable<Package>> GetAllPackagesAsync()
    {
        return await packageRepository.GetAllPackagesAsync();
    }

    public async Task<Package> GetPackageByIdAsync(int id)
    {
        return await packageRepository.GetPackageByIdAsync(id);
    }
    
    public async Task CreatePackageAsync(PackageDto packageDto)
    {
        var package = new Package
        {
            PackageName = packageDto.PackageName,
            PackagePrice = packageDto.PackagePrice = Convert.ToDouble(packageDto.PackagePrice),
            NoOfPhotos = packageDto.NoOfPhotos
        };
        
        await packageRepository.CreatePackageAsync(package);
        
    }

    public async Task UpdatePackageAsync(int id, PackageDto packageDto)
    {
        var package = await packageRepository.GetPackageByIdAsync(id);
        package.PackageName = packageDto.PackageName;
        package.PackagePrice = Convert.ToDouble(packageDto.PackagePrice);
        package.NoOfPhotos = packageDto.NoOfPhotos;
        
        await packageRepository.UpdatePackageAsync(package);
    }

    public async Task DeletePackageAsync(int id)
    {
        await packageRepository.DeletePackageAsync(id);
    }
}

