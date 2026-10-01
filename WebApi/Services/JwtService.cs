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

    public Task<Guid?> GetIdentityProviderIdAsync()
    {
        // The JWT is sent with each protected request in the Authorization header.
        var authHeader = httpContextAccessor.HttpContext?
            .Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authHeader))
        {
            // The client did not send an Authorization header,
            // so there is no JWT for us to validate.
            return Task.FromResult<Guid?>(null);
        }

        // Remove "Bearer " so that only the JWT remains.
        var token = authHeader
            .Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase)
            .Trim();

                if (string.IsNullOrEmpty(token))
        {
            return Task.FromResult<Guid?>(null);
        }

        // Validate the JWT signature using the key from User Secrets.
        // We are not using issuer/audience validation yet because
        // our current learning-project token does not define those.
        // Keep JWT claim names unchanged when creating the ClaimsPrincipal.
        // This lets us read the JWT's "sub" claim as "sub".
        var handler = new JwtSecurityTokenHandler
        {
            MapInboundClaims = false
        };

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

            if (!Guid.TryParse(identityProviderId, out var userId))
            {
                return Task.FromResult<Guid?>(null);
            }

            return Task.FromResult<Guid?>(userId);
        }
        catch (SecurityTokenException)
        {
            // Invalid signature or otherwise invalid JWT.
            return Task.FromResult<Guid?>(null);
        }
    }

    // Creates a JWT containing the identity-provider ID.
    // The same signing key is used here and during validation,
    // so the API can later verify that this token was created with our key.
    public string CreateToken(Guid identityProviderId)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_signingKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new System.Security.Claims.Claim("sub", identityProviderId.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(token);
    }
}