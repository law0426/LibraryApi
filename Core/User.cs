namespace Core;

public class User
{
    //Must contain what? Nvm id for now.
    //Just string.
    //And List of books they're borrowing.
    public string Name{get;}
    public List<Book> books{get;}
    
    public User(string name)
    {
        Name = name;
        books = [];
    }

    public void Receive(Book book)
    {
        books.Add(book);
    }
}