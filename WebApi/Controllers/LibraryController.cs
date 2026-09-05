// using Core.Models; //unnecessary due to references. but good for clarity.
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class LibraryController(ILogger<LibraryController> logger) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> GetAsync()
    {
        logger.LogInformation("Received Get request on 'user' route!");
        return Ok();
    }
}