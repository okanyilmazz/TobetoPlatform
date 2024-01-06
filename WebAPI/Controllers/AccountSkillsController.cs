using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSkillsController : ControllerBase
{
    IAccountSkillService _accountSkillsService;

    public AccountSkillsController(IAccountSkillService accountSkillsService)
    {
        _accountSkillsService = accountSkillsService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSkillsService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountSkillsService.GetByIdAsync(Id);
        return Ok(result);
    }

    [CacheRemove("AccountSkills.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSkillRequest createAccountSkillRequest)
    {
        var result = await _accountSkillsService.AddAsync(createAccountSkillRequest);
        return Ok(result);
    }


    [CacheRemove("AccountSkills.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSkillRequest updateAccountSkillRequest)
    {
        var result = await _accountSkillsService.UpdateAsync(updateAccountSkillRequest);
        return Ok(result);
    }


    [CacheRemove("AccountSkills.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountSkillRequest deleteAccountSkillRequest)
    {
        var result = await _accountSkillsService.DeleteAsync(deleteAccountSkillRequest);
        return Ok(result);
    }
}
