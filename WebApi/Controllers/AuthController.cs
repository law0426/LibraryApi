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

        // If the client did not send an Authorization header,
        // there is no JWT for us to read.
        if (string.IsNullOrEmpty(authHeader))
        {
            return BadRequest("Authorization header is missing.");
        }
        // Remove the "Bearer " prefix so that we are left with
        // only the JWT itself.
        var token = authHeader
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase)
            .Trim();

        // JwtSecurityTokenHandler understands the JWT format
        // and can turn the string into an object we can inspect.
        var handler = new JwtSecurityTokenHandler();
        // JwtSecurityTokenHandler comes from the System.IdentityModel.Tokens.Jwt
        // package. It provides .NET types and methods for working with JWTs.
        //
        // ReadJwtToken() parses the JWT string and gives us a JwtSecurityToken
        // object whose header and claims we can inspect.
        //
        // IMPORTANT: this only reads/parses the token.
        // It does NOT verify that the token was signed by a trusted issuer.
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