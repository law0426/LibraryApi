namespace WebApi.Services;
using Core.Models;

public interface ILibraryService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdentityProviderIdAsync(Guid identityProviderId);

    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> PostBookAsync(Book book);
    // Gets only the books currently borrowed by the specified user.
    // The identityProviderId will eventually come from the validated JWT.
    Task<IEnumerable<Book>> GetBooksForUserAsync(Guid identityProviderId);
}