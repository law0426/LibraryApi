//using LibraryApi.WebApi;
//already using?


namespace Tests;

public class WebApiTests
{
    [Fact]
    /*
    We're first initializing a book. Adding it to the library book list.
    Then using a service to return the book.
    */
    public async Task GetBook_ReturnsBook_WhenBookExists()
    {
        // Arrange
        //Book = new book("Name");
        // Library.build books with book?
        // Build task?

        // Act
        // result = Await result of task?
        
        // Assert
        // assert.equal(book, result);

        
        // Arrange
        var service = new BookService();

        // Act
        var book = await service.GetBook(1); //Can't get something I haven't initialized. Build initializer for this.
        //Library = new library(); if no arguments are given for new library, set up default book list. 

        // Assert
        Assert.NotNull(book);
    }
}