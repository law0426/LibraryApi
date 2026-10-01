namespace Core.Models;

public class User
{
    // Database-generated internal ID.
    public int Id { get; private set; }

    // Identifies this user in the identity system.
    // This is separate from the database-generated Id.
    // null! suppresses the nullable warning during compilation
    // while EF Core populates this property when materializing the entity.
    // null! will not actually allow nullability at runtime.
    public Guid IdentityProviderId { get; private set; }

    public string Name { get; private set; }

    // Password is plain text for now; hashing can be added later.
    public string Password { get; private set; }

    public List<Book> Books { get; private set; } = [];

    private User()
    {
        Name = "";
        Password = "";
    }

    public User(string name, string password)
    {
        // Automatically generate the user's identity when the account is created.
        IdentityProviderId = Guid.CreateVersion7();
        Name = name;
        Password = password;
    }

    public void Receive(Book book)
    {
        Books.Add(book);
    }
}
