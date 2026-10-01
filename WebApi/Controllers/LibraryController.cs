// using Core.Models; //unnecessary due to references. but good for clarity.
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class LibraryController(
    ILibraryService libraryService,
    ILogger<LibraryController> logger,
    IJwtService jwtService
) : ControllerBase
{
    private readonly ILibraryService _libraryService = libraryService;
    private readonly IJwtService _jwtService = jwtService;
    [HttpGet("users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        logger.LogInformation("Received Get request on 'user' route!");
        return Ok();
    }
    [HttpGet("books")]
    public async Task<IActionResult> GetBooksAsync()
    {
        logger.LogInformation("Received Get request on 'books' route!");
        var books = await libraryService.GetBooksAsync();
        return Ok(books);
    }
    [HttpPost("books")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> PostBookAsync(Book book)
    {
        logger.LogInformation("Received Post request on 'Books' route!");
        //TODO: Code comparison for detailed response below: 
        // var item = await dto.AsyncInsertTask(context);
        // return CreatedAtAction(nameof(AsyncGet), new {id = item.Id}, item);
        //Should I make a dto?
        var registeredBook = await libraryService.PostBookAsync(book);
        logger.LogInformation($"successfully registered: {registeredBook}");
        return Created();
    }
    // Gets the authenticated user's borrowed books.
    // JwtService validates the JWT and extracts the user's identity.
    [HttpGet("my-borrows")]
    public async Task<IActionResult> GetMyBorrows()
    {
        // JwtService validates the JWT before returning the identity.
        var identityProviderId = await _jwtService.GetIdentityProviderIdAsync();

        if (identityProviderId is not Guid userId)
        {
            return Unauthorized();
        }

        var books = await _libraryService
            .GetBooksForUserAsync(userId);

        return Ok(books);
    }
}