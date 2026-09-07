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
        Console.WriteLine("2 "+book.Title); 
        Book registeredBook = book;
        Console.WriteLine("3 registered" + registeredBook.Title); 
        Books.Add(registeredBook);
        Console.WriteLine("3.5  from book list" + Books[0]); 
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
