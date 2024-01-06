using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Core.Entities;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<User> Register(RegisterAuthRequest registerAuthRequest, string password);
        Task<User> Login(LoginAuthRequest loginAuthRequest);
        Task UserExists(string email);
        Task<AccessToken> CreateAccessToken(User user);
    }
}
