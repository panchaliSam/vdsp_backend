using Microsoft.AspNetCore.Mvc;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;
using Server.DomainLayer.Models.Entities;

namespace Server.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StaffController(IStaffService staffService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStaff()
    {
        var staff = await staffService.GetAllStaffAsync();
        return Ok(staff);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStaffById(int id)
    {
        var staff = await staffService.GetStaffByIdAsync(id);
        return Ok(staff);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff(StaffDto staffDto)
    {
        await staffService.CreateStaffAsync(staffDto);
        return CreatedAtAction(nameof(GetStaffById), new{id=staffDto.StaffFirstName}, new {message = "Created successfully"});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStaff(int id, StaffDto staffDto)
    {
        await staffService.UpdateStaffAsync(id, staffDto);
        return Ok(new{message="Updated successfully"});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStaff(int id)
    {
        await staffService.DeleteStaffAsync(id);
        return Ok(new{message="Deleted successfully"});
    }
}
