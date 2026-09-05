namespace WebApi.Services;
using Core.Models;

//This should take the library class and do end point logic to it.

//Did this need to inherit anything?

public class LibraryService : ILibraryService
{
    Library library = new();

    public LibraryService(bool testing)
    {
        if (testing)
        {
            //initialize with test values;
            Console.WriteLine("LibraryService(1); Initialized. TEST ENVIRONTMENT DETECTED.");
            Console.WriteLine("Initializing Library with test values.");
        }
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}