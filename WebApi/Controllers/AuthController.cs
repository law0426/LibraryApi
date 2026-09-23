using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    // GET /Auth/token
    //
    // This endpoint does NOT authenticate anyone yet.
    // It receives an existing JWT and lets us inspect its contents.
    [HttpGet("token")]
    public IActionResult GetToken()
    {
        // The client sends the JWT in the HTTP Authorization header:
        // Authorization: Bearer eyJhbGciOi...
        // At this point it is just a string.
        var authHeader = Request.Headers.Authorization.ToString();

        // Remove the "Bearer " prefix so that we are left with
        // only the JWT itself.
        var token = authHeader
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase)
            .Trim();

        // JwtSecurityTokenHandler understands the JWT format
        // and can turn the string into an object we can inspect.
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        // A JWT contains claims such as:
        // "sub"  -> subject/user identifier
        // "name" -> name
        // etc.
        // We return the claims so we can see what was inside the token.
        
        //Are these the only claims? TODO: FURTHER READING.
        return Ok(jwt.Claims.Select(claim => new
        {
            claim.Type,
            claim.Value
        }));
    }
}