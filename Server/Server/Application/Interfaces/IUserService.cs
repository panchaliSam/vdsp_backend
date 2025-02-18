using Server.Application.DTOs;

namespace Server.Application.Interfaces;

public interface IUserService
{
    Task<bool> SignUpAsync(UserDto userDto);
}

