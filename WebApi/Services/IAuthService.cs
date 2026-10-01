namespace WebApi.Services;

using Core.Models;

public interface IAuthService
{
    Task<User> RegisterUserAsync(string name, string password);

    Task<User?> AuthenticateUserAsync(string name, string password);
}