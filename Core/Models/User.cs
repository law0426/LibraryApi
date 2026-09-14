namespace Core.Models;

public class User
{
    //Must contain what? Nvm id for now.
    //Just string.
    //And List of books they're borrowing.
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Book> Books { get; private set; } = [];

    private User()
    {
        Name = "";
    }

    public User(string name)
    {
        Name = name;
    }

    public void Receive(Book book)
    {
        Books.Add(book);
    }
}