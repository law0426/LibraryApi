namespace WebApi.Services;
using Core.Models;

public interface ILibraryService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<Book> PostBookAsync(Book book);
    // Task<UserTask> AsyncAddTask(string title, string description, DateTime dueDate);
}