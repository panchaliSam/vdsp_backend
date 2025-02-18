using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs;
using Server.Application.Interfaces;

namespace Server.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] UserDto userDto)
    {
        try
        {
            var result = await userService.SignUpAsync(userDto);
            return Ok(new { Success = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}