using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services;

public class JwtService(IHttpContextAccessor httpContextAccessor) : IJwtService
{
    // TODO: Validate the JWT signature before trusting its claims.
    // For now, this service only reads the token and extracts "sub".

    public Task<string?> GetIdentityProviderIdAsync()
    {
        // The JWT is sent with each protected request in the Authorization header.
        var authHeader = httpContextAccessor.HttpContext?
            .Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authHeader))
        {
            return Task.FromResult<string?>(null);
        }

        // Remove "Bearer " so that only the JWT remains.
        var token = authHeader
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase)
            .Trim();

        if (string.IsNullOrEmpty(token))
        {
            return Task.FromResult<string?>(null);
        }

        // TODO: Replace this parsing-only step with proper JWT validation.
        // ReadJwtToken() does NOT verify the token's signature.
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        // "sub" identifies the user in the identity provider.
        var identityProviderId = jwt.Claims
            .FirstOrDefault(claim => claim.Type == "sub")
            ?.Value;

        return Task.FromResult(identityProviderId);
    }
}