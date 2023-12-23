﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionsController : Controller
{
    ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _sessionService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateSessionRequest createSessionRequest)
    {
        var result = await _sessionService.AddAsync(createSessionRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSessionRequest updateSessionRequest)
    {
        var result = await _sessionService.UpdateAsync(updateSessionRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteSessionRequest deleteSessionRequest)
    {
        var result = await _sessionService.DeleteAsync(deleteSessionRequest);
        return Ok(result);
    }
}