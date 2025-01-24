using Microsoft.AspNetCore.Mvc;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;

namespace Server.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RoleController(IRoleService roleService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await roleService.GetAllRoleAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var role = await roleService.GetRoleByIdAsync(id);
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(RoleDto roleDto)
    {
        await roleService.CreateRoleAsync(roleDto);
        return CreatedAtAction(nameof(GetRoleById), new { id = roleDto.RoleName }, new { message = "Created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, RoleDto roleDto)
    {
        await roleService.UpdateRoleAsync(id, roleDto);
        return Ok(new{message = "Updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        await roleService.DeleteRoleAsync(id);
        return Ok(new{message = "Deleted successfully" });
    }
}
