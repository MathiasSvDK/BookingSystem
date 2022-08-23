using IdentityModel.Client;

namespace BlazorWeb.Services
{
	public interface ITokenService
	{
		Task<TokenResponse> GetToken(string scope);
	}
}
