using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountAnswersController : ControllerBase
{
    IAccountAnswerService _accountAnswersService;

    public AccountAnswersController(IAccountAnswerService accountAnswersService)
    {
        _accountAnswersService = accountAnswersService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _accountAnswersService.GetListAsync();
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountAnswersService.GetByIdAsync(id);
        return Ok(result);
    }


    [CustomValidation(typeof(CreateAccountAnswerRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountAnswerRequest createAccountAnswerRequest)
    {
        var result = await _accountAnswersService.AddAsync(createAccountAnswerRequest);
        return Ok(result);
    }



    [CustomValidation(typeof(UpdateAccountAnswerRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountAnswerRequest updateAccountAnswerRequest)
    {
        var result = await _accountAnswersService.UpdateAsync(updateAccountAnswerRequest);
        return Ok(result);
    }


    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountAnswerRequest deleteAccountAnswerRequest)
    {
        var result = await _accountAnswersService.DeleteAsync(deleteAccountAnswerRequest);
        return Ok(result);
    }
}
