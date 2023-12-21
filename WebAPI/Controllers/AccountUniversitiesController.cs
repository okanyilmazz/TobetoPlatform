using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountUniversitiesController : ControllerBase
{
    IAccountUniversityService _accountUniversityService;

    public AccountUniversitiesController(IAccountUniversityService accountUniversityService)
    {
        _accountUniversityService = accountUniversityService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _accountUniversityService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountUniversityRequest createAccountUniversityRequest)
    {
        var result = await _accountUniversityService.AddAsync(createAccountUniversityRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountUniversityRequest updateAccountUniversityRequest)
    {
        var result = await _accountUniversityService.UpdateAsync(updateAccountUniversityRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountUniversityRequest deleteAccountUniversityRequest)
    {
        var result = await _accountUniversityService.DeleteAsync(deleteAccountUniversityRequest);
        return Ok(result);
    }
}
