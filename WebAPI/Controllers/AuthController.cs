﻿using Business.Abstracts;
using Business.Dtos.Requests.AuthRequests;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthRequest loginAuthRequest)
    {
        var userToLogin = await _authService.Login(loginAuthRequest);
        var result = await _authService.CreateAccessToken(userToLogin);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterAuthRequest registerAuthRequest)
    {
        var registerResult = await _authService.Register(registerAuthRequest, registerAuthRequest.Password);
        return Ok(registerResult);
    }
}