namespace WebApi.Services;
using Core.Models;

public interface ILibraryService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdentityProviderIdAsync(string identityProviderId);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> PostBookAsync(Book book);
    // Task<UserTask> AsyncAddTask(string title, string description, DateTime dueDate);
}