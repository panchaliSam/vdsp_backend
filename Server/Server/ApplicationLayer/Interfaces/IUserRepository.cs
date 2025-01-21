namespace Server.ApplicationLayer.Interfaces;

public interface IUserRepository
{
    Task<bool> AddUserAsync(string email, string userToken);
    Task<bool> IsUserExistsAsync(string email);
}