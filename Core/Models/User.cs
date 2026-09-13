namespace Core.Models;

public class User
{
    //Must contain what? Nvm id for now.
    //Just string.
    //And List of books they're borrowing.
    public int Id { get; private set; }
    public string Name{get;}
    public List<Book> Books{get;}
    
    public User(string name)
    {
        Name = name;
        Books = [];
    }

    public void Receive(Book book)
    {
        Books.Add(book);
    }
}