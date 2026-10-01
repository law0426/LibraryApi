namespace WebApi.Services;

using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly LibraryDbContext _db;

    public AuthService(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task<User> RegisterUserAsync(string name, string password)
    {
        var user = new User(name, password);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return user;
    }

    public async Task<User?> AuthenticateUserAsync(string name, string password)
    {
        // Placeholder authentication: plaintext password comparison.
        return await _db.Users
            .FirstOrDefaultAsync(user =>
                user.Name == name &&
                user.Password == password);
    }
}