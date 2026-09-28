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
    // GET /Library/my-borrows
    //
    // TODO: Get the authenticated user's identity from the validated JWT.
    // For now, authentication is not implemented, so the identity is only
    // represented by a placeholder.
    //
    // Once authentication is implemented:
    // 1. Get the identityProviderId from the validated JWT.
    // 2. Pass that identity to the library service.
    // 3. The service returns only that user's borrowed books.
    [HttpGet("my-borrows")]
    public async Task<IActionResult> GetMyBorrows()
    {
        // TODO: This currently only parses the JWT.
        // Later, JwtService must also validate its signature before we trust "sub".
        var identityProviderId = await _jwtService.GetIdentityProviderIdAsync();

        if (identityProviderId is null)
        {
            return Unauthorized();
        }

        var books = await _libraryService
            .GetBooksForUserAsync(identityProviderId);

        return Ok(books);
    }
}