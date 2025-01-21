using Server.ApplicationLayer.DTOs;

namespace Server.ApplicationLayer.Interfaces;

public interface IUserService
{
    Task<bool> SignUpAsync(UserDto userDto);
    Task<bool> SignInAsync(string email, string userToken);
}

