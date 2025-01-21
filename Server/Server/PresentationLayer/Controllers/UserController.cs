using Microsoft.AspNetCore.Mvc;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;

namespace Server.PresentationLayer.Controllers;

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

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] UserDto userDto)
    {
        try
        {
            var result = await userService.SignInAsync(userDto.Email, userDto.UserToken);
            if (!result) return Unauthorized(new { Error = "User does not exist." });

            return Ok(new { Success = true });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}