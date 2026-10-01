namespace WebApi.Services;

public interface IJwtService
{
    // from the "sub" claim.
    Task<Guid?> GetIdentityProviderIdAsync();
    
    // Create a JWT for an authenticated identity-provider user.
    string CreateToken(Guid identityProviderId);
}