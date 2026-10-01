using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(
    IJwtService jwtService,
    IAuthService authService
) : ControllerBase
{
    private readonly IJwtService _jwtService = jwtService;
    private readonly IAuthService _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = await _authService.RegisterUserAsync(
            request.Name,
            request.Password);

        return Ok(new
        {
            user.Id,
            user.IdentityProviderId,
            user.Name
        });
    }
    [HttpPost("token")]
    public async Task<IActionResult> GetToken([FromBody] LoginRequest request)
    {
        var user = await _authService.AuthenticateUserAsync(
            request.Name,
            request.Password);

        if (user is null)
        {
            return Unauthorized();
        }

        // User already has a generated IdentityProviderId.
        var token = _jwtService.CreateToken(user.IdentityProviderId);

        return Ok(token);
    }
}

// Request body used when creating a new account.
public record RegisterRequest(string Name, string Password);
public record LoginRequest(string Name, string Password);