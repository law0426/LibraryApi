namespace Core.Models;

public class User
{
    //Must contain what? Nvm id for now.
    //Just string.
    //And List of books they're borrowing.
    public int Id { get; private set; }
    // Identifies this user in the identity system.
    // This is separate from the database-generated Id.
    public string IdentityProviderId { get; private set; }
    public string Name { get; private set; }
    public List<Book> Books { get; private set; } = [];

    private User()
    {
        Name = "";
    }

    public User(string name, string identityProviderId)
    {
        Name = name;
        IdentityProviderId = identityProviderId;
    }

    public void Receive(Book book)
    {
        Books.Add(book);
    }
}