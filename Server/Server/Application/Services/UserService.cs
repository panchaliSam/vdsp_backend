using FirebaseAdmin.Auth;
using Server.Application.Interfaces;
using Server.ApplicationLayer.DTOs;
using Server.ApplicationLayer.Interfaces;

namespace Server.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> SignUpAsync(UserDto userDto)
    {
        var isUserExists = await userRepository.IsUserExistsAsync(userDto.Email);
        if (isUserExists)
        {
            throw new Exception("User already exists.");
        }

        bool isTokenValid = await VerifyFirebaseToken(userDto.UserToken);
        if (!isTokenValid)
        {
            throw new Exception("Invalid Firebase token.");
        }

        return await userRepository.AddUserAsync(userDto.Email, userDto.UserToken);
    }
    
    private async Task<bool> VerifyFirebaseToken(string firebaseToken)
    {
        try
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(firebaseToken);
            return decodedToken != null;
        }
        catch
        {
            return false;
        }
    }
}