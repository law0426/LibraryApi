namespace WebApi.Services;

public interface IJwtService
{
    // TODO: Validate the JWT and extract the user's identity-provider ID
    // from the "sub" claim.
    Task<string?> GetIdentityProviderIdAsync();
}