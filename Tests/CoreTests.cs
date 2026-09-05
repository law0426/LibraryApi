using Core.Models;

namespace Tests;

public class CoreTests
{
    [Fact]
    public void Book_CanBeAded_AndBorrowed()
    {
        //Arrange
        List<Book> books = new List<Book>();
        books.Add(new Book("Book1"));
        //Act
        Book book = books[0];
        book.Borrow();
        //Assert.
        Assert.True(book.Borrowed);
    }


    [Fact]
    public void Book_WillNotBeBorrowed_IfAlreadyBorrowed()
    {
        //Arrange
         Book book = new("Book1");
        //Act
        book.Borrow();
        //Assert.
        Assert.Throws<InvalidOperationException>(() => book.Borrow());
    }
    [Fact]
    public void Book_CanBeReturned_AndSet_BorrowedToFalse()
    {
        //Arrange
         Book book = new("Book1");
         book.Borrow();
        //Act
        book.Return();
        //Assert.
        Assert.False(book.Borrowed);
    }

    [Fact]
    public void Book_ThrowsError_WhenReturningUnborrowedBook()
    {
        //Arrange
        Book book = new("Book1");
        
        //Assert.
        Assert.Throws<InvalidOperationException>(()=>book.Return());
    }
    [Fact]
    public void User_CanReceiveBook_AndBookMatches()
    {
        //Arrange
        Book book = new("Book1");
        User user = new("Bob");

        user.Receive(book);
        
        //Assert.
        Assert.NotEmpty(user.Books);
        Assert.Equal(book, user.Books[0]);
    }
}
