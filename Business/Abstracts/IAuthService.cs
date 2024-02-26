﻿using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Responses.AuthResponses;
using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<LoginResponse> Register(RegisterAuthRequest registerAuthRequest, string password);
    Task<User> Login(LoginAuthRequest loginAuthRequest);
    Task<LoginResponse> CreateAccessToken(User user);
}
