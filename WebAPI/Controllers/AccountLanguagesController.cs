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
public class AccountLanguagesController : ControllerBase
{
    IAccountLanguageService _accountLanguageService;

    public AccountLanguagesController(IAccountLanguageService AccountLanguageService)
    {
        _accountLanguageService = AccountLanguageService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountLanguageService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountLanguageService.GetByIdAsync(id);
        return Ok(result);
    }


    [CacheRemove("AccountLanguages.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountLanguageRequest createAccountLanguageRequest)
    {
        var result = await _accountLanguageService.AddAsync(createAccountLanguageRequest);
        return Ok(result);
    }


    [CacheRemove("AccountLanguages.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountLanguageRequest updateAccountLanguageRequest)
    {
        var result = await _accountLanguageService.UpdateAsync(updateAccountLanguageRequest);
        return Ok(result);
    }


    [CacheRemove("AccountLanguages.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountLanguageRequest deleteAccountLanguageRequest)
    {
        var result = await _accountLanguageService.DeleteAsync(deleteAccountLanguageRequest);
        return Ok();
    }
}
