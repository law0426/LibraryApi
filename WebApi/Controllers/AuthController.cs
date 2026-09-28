using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IJwtService jwtService) : ControllerBase
{
    private readonly IJwtService _jwtService = jwtService;

    // GET /Auth/token?identityProviderId=1234567890
    //
    // This endpoint represents our identity provider issuing a JWT.
    //
    // The identityProviderId is supplied directly for now because this
    // is a learning project and we are acting as our own identity provider.
    //
    // IMPORTANT:
    // In a real system, we would first authenticate the person requesting
    // the token. We would NOT simply trust an ID supplied in the URL.
    [HttpGet("token")]
    public IActionResult GetToken([FromQuery] string identityProviderId)
    {
        // The caller must provide an identity-provider ID so that we know
        // which user the JWT should represent.
        if (string.IsNullOrWhiteSpace(identityProviderId))
        {
            return BadRequest("identityProviderId is required.");
        }

        // JwtService is responsible for knowing how to construct and sign
        // the JWT. AuthController only asks it to create the token.
        var token = _jwtService.CreateToken(identityProviderId);

        // Return the JWT to the client.
        //
        // The client can then send this token on later protected requests:
        //
        // Authorization: Bearer <JWT>
        return Ok(token);
    }
}