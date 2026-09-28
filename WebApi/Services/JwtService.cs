using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services;

public class JwtService(
    IHttpContextAccessor httpContextAccessor,
    IConfiguration configuration
) : IJwtService
{
    // TODO: Validate the JWT signature before trusting its claims.
    // The signing key will come from User Secrets through configuration.
    private readonly string _signingKey =
        configuration["Jwt:SigningKey"]
        ?? throw new InvalidOperationException(
            "JWT signing key is not configured.");

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

        // Validate the JWT signature using the key from User Secrets.
        // We are not using issuer/audience validation yet because
        // our current learning-project token does not define those.
        var handler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_signingKey)),

            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };

        try
        {
            // ValidateToken() checks the signature before giving us
            // the claims we are going to trust.
            var principal = handler.ValidateToken(
                token,
                validationParameters,
                out _);

            // "sub" identifies the user in the identity provider.
            var identityProviderId = principal.Claims
                .FirstOrDefault(claim => claim.Type == "sub")
                ?.Value;

            return Task.FromResult(identityProviderId);
        }
        catch (SecurityTokenException)
        {
            // Invalid signature or otherwise invalid JWT.
            return Task.FromResult<string?>(null);
        }
    }

    // Creates a JWT containing the identity-provider ID.
    // The same signing key is used here and during validation,
    // so the API can later verify that this token was created with our key.
    public string CreateToken(string identityProviderId)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_signingKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new System.Security.Claims.Claim("sub", identityProviderId)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(token);
    }
}