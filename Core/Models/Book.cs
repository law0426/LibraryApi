namespace Core.Models;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public bool Borrowed { get; private set; } = false;

    private Book()
    {
        Title = "";
    }

    public Book(string title)
    {
        Title = title;
    }

    public void Borrow()
    {
        if(Borrowed == true)
        {
            throw new InvalidOperationException("Book is already borrowed");
        }
        else Borrowed = true;
    }

    public void Return()
    {
        Borrowed = false;
    }
    
}
