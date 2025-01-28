using Microsoft.AspNetCore.Mvc;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.ApplicationLayer.Services;
using Server.DomainLayer.Models.Entities;

namespace Server.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PackageController(IPackageService packageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPackages()
    {
        var packages = await packageService.GetAllPackagesAsync();
        return Ok(packages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPackageById(int id)
    {
        var package = await packageService.GetPackageByIdAsync(id);
        return Ok(package);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePackage(PackageDto packageDto)
    {
        await packageService.CreatePackageAsync(packageDto);
        return CreatedAtAction(nameof(GetPackageById), new{id = packageDto.PackageName}, new{message = "Created successfully"});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePackage(int id, PackageDto packageDto)
    {
        await packageService.UpdatePackageAsync(id, packageDto);
        return Ok(new{message = "Updated successfully"});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePackage(int id)
    {
        await packageService.DeletePackageAsync(id);
        return Ok(new{message = "Deleted successfully"});
    }
}