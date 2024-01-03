using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountLessonsController : ControllerBase
{
    IAccountLessonService _accountLessonService;

    public AccountLessonsController(IAccountLessonService accountLessonService)
    {
        _accountLessonService = accountLessonService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _accountLessonService.GetListAsync();
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountLessonService.GetByIdAsync(id);
        return Ok(result);
    }


    [CustomValidation(typeof(CreateAccountLessonRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountLessonRequest createAccountLessonRequest)
    {
        var result = await _accountLessonService.AddAsync(createAccountLessonRequest);
        return Ok(result);
    }


    [CustomValidation(typeof(UpdateAccountLessonRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountLessonRequest updateAccountLessonRequest)
    {
        var result = await _accountLessonService.UpdateAsync(updateAccountLessonRequest);
        return Ok(result);
    }


    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountLessonRequest deleteAccountLessonRequest)
    {
        var result = await _accountLessonService.DeleteAsync(deleteAccountLessonRequest);
        return Ok(result);
    }
}
