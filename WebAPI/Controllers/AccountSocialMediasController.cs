using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSocialMediasController : ControllerBase
{
    IAccountSocialMediaService _accountSocialMediaService;

    public AccountSocialMediasController(IAccountSocialMediaService examService)
    {
        _accountSocialMediaService = examService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountSocialMediaService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountSocialMediaService.GetByIdAsync(Id);
        return Ok(result);
    }


    [CacheRemove("AccountSocialMedias.Get")]
    [CustomValidation(typeof(CreateAccountSocialMediaRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSocialMediaRequest createAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.AddAsync(createAccountSocialMediaRequest);
        return Ok(result);
    }


    [CacheRemove("AccountSocialMedias.Get")]
    [CustomValidation(typeof(UpdateAccountSocialMediaRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.UpdateAsync(updateAccountSocialMediaRequest);
        return Ok(result);
    }


    [CacheRemove("AccountSocialMedias.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountSocialMediaRequest deleteAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.DeleteAsync(deleteAccountSocialMediaRequest);
        return Ok(result);
    }
}
