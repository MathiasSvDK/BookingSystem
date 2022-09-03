using IdentityModel.Client;

namespace Web.Service.IdentityService
{

    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
