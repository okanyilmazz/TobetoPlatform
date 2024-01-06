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
public class AccountUniversitiesController : ControllerBase
{
    IAccountUniversityService _accountUniversityService;

    public AccountUniversitiesController(IAccountUniversityService accountUniversityService)
    {
        _accountUniversityService = accountUniversityService;
    }


    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountUniversityService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _accountUniversityService.GetByIdAsync(Id);
        return Ok(result);
    }


    [CacheRemove("AccountUniversities.Get")]
    [CustomValidation(typeof(CreateAccountUniversityRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountUniversityRequest createAccountUniversityRequest)
    {
        var result = await _accountUniversityService.AddAsync(createAccountUniversityRequest);
        return Ok(result);
    }


    [CacheRemove("AccountUniversities.Get")]
    [CustomValidation(typeof(UpdateAccountUniversityRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountUniversityRequest updateAccountUniversityRequest)
    {
        var result = await _accountUniversityService.UpdateAsync(updateAccountUniversityRequest);
        return Ok(result);
    }


    [CacheRemove("AccountUniversities.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountUniversityRequest deleteAccountUniversityRequest)
    {
        var result = await _accountUniversityService.DeleteAsync(deleteAccountUniversityRequest);
        return Ok(result);
    }
}
