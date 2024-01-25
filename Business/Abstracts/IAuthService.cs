using Business.Dtos.Requests.AuthRequests;
using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<User> Register(RegisterAuthRequest registerAuthRequest, string password);
    Task<User> Login(LoginAuthRequest loginAuthRequest);
    Task<AccessToken> CreateAccessToken(User user);
}
