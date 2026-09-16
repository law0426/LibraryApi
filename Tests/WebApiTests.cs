//using LibraryApi.WebApi;
//already using?


namespace Tests;

using Core.Models;
using Microsoft.AspNetCore.Mvc.Testing; 
using System.Net.Http.Json;
using WebApi.Services;
using System.Net;

//dotnet add MyApi.Tests package Microsoft.AspNetCore.Mvc.Testing



public class WebApiTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public WebApiTests(ApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUsers_ReturnsOk()
    {
        var response = await _client.GetAsync("/Library/users");
        var statusCode = response.StatusCode;
        Console.WriteLine($"Status: {(int)response.StatusCode}");
        Console.WriteLine($"Reason: {response.ReasonPhrase}");
        Console.WriteLine($"Body: {await response.Content.ReadAsStringAsync()}");
        //response.EnsureSuccessStatusCode();
    }
    //Vestigial code: Postbook is the actual important test to keep active.
    //This was just a temporary test to begin with.
    // [Fact]
    // public async Task LibraryService_ReturnsBook()
    // {
    //     Book book = new Book("Book1");
    //     LibraryService service = new LibraryService();
    //     var response = await service.PostBookAsync(book);
        
    //     //var response = await _client.PostAsJsonAsync("/Library/books", book);
    //     Assert.Equal(book, response);
    // }
    [Fact]
    public async Task PostBook_ReturnsCreated()
    {
        Book book = new Book("Book1");
        var response = await _client.PostAsJsonAsync("/Library/books", book);
        Console.WriteLine(" WE FOUND THE THING: " + response);
        // Assert.Equal(); 
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetBooks_ReturnsStoredBooks()
    {
        var response = await _client.GetAsync("/Library/books");

        response.EnsureSuccessStatusCode();

        var books = await response.Content.ReadFromJsonAsync<List<Book>>();

        Assert.NotNull(books);
        Assert.Contains(books, book => book.Title == "Book1");
    }
    
    [Fact]
    public async Task GetHealth_ReturnsOk()
    {
        var response = await _client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

