namespace Core.Models;

public class Library
{

    public List<User> Users{get; private set;}
    public List<Book> Books{get; private set;}

    public Library()
    {
        Users = new List<User>();
        Books = new List<Book>();
    }


    public async Task<Book> RegisterBook(Book book)
    {
        Book registeredBook = book;
        Books.Add(registeredBook);
        return(registeredBook);
    }

    // public bool Borrowed{get; private set;}

    // public Book(string title){
    //     Title = title;
    //     Borrowed = false;
    // }

    // public void Borrow()
    // {
    //     if(Borrowed == true)
    //     {
    //         throw new InvalidOperationException("Book is already borrowed");
    //     }
    //     else Borrowed = true;
    // }

    // public void Return()
    // {
    //     Borrowed = false;
    // }
    
}
