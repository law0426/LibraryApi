// using Core.Models; //unnecessary due to references. but good for clarity.
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class LibraryController(ILibraryService libraryService, ILogger<LibraryController> logger) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> GetAsync()
    {
        logger.LogInformation("Received Get request on 'user' route!");
        return Ok();
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
}