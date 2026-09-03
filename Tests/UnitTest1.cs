using Core;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Book_CanBeAded_AndBorrowed()
    {
        //Arrange
        List<Book> books = new List<Book>();
        books.Add(new Book("Book1"));
        //Act
        Book book = books[1];
        book.Borrow();
        //Assert.
        Assert.True(book.Borrowed);
    }
}
