namespace WebApi.Services;
using Core.Models;

public interface ILibraryService
{
    Task<IEnumerable<User>> GetUsersAsync();

}