﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
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
        var result = _authService.CreateAccessToken(userToLogin);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterAuthRequest registerAuthRequest)
    {
        //await _authService.UserExists(registerAuthRequest.Email);
        var registerResult = await _authService.Register(registerAuthRequest, registerAuthRequest.Password);

        var result = _authService.CreateAccessToken(registerResult);
        if (result != null)
        {
            return Ok(result);
        }
        //return BadRequest(result.Message);
        return Ok(registerResult);
    }
}