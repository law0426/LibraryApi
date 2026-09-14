namespace WebApi.Services;
using Core.Models;
using Data;



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

    public async Task<Book> PostBookAsync(Book book)
    {
        _db.Books.Add(book);
        await _db.SaveChangesAsync();

        return book;
    }
}