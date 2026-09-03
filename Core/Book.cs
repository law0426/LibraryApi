namespace Core;

public class Book
{

    public string Title{get;}
    public bool Borrowed{get; private set;}

    public Book(string title){
        Title = title;
        Borrowed = false;
    }

    public void Borrow()
    {
        if(Borrowed == true)
        {
            throw new InvalidOperationException("Book is already borrowed");
        }
        else Borrowed = true;
    }
    
}
