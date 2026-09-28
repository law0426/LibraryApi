namespace WebApi.Services;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;

public class LibraryService : ILibraryService
{
    Library library = new();

    private readonly LibraryDbContext _db;

    public LibraryService(LibraryDbContext db)
    {
        _db = db;
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByIdentityProviderIdAsync(string identityProviderId)
    {
        return await _db.Users
            .Include(user => user.Books)
            .FirstOrDefaultAsync(user => user.IdentityProviderId == identityProviderId);
    }
    
    // Gets only the books currently borrowed by the specified user.
    // The identityProviderId will eventually come from the validated JWT.
    public async Task<IEnumerable<Book>> GetBooksForUserAsync(string identityProviderId)
    {
        var user = await _db.Users
            .Include(user => user.Books)
            .FirstOrDefaultAsync(user => user.IdentityProviderId == identityProviderId);

        if (user is null)
        {
            return [];
        }

        return user.Books;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        //because of the task structure, what does this actually look like? 
        //The return type is weird, and we should just have a list?
        //Do we just make it .tolist();?
        return await _db.Books.ToListAsync();
    }
    public async Task<Book> PostBookAsync(Book book)
    {
        _db.Books.Add(book);
        await _db.SaveChangesAsync();

        return book;
    }
    
}