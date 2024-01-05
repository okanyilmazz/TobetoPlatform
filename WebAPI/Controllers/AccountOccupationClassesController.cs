using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountOccupationClassesController : ControllerBase
{
    IAccountOccupationClassService _accountOccupationClass;

    public AccountOccupationClassesController(IAccountOccupationClassService occupationClassOfAccountService)
    {
        _accountOccupationClass = occupationClassOfAccountService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountOccupationClass.GetListAsync(pageRequest);
        return Ok(result);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountOccupationClass.GetByIdAsync(id);
        return Ok(result);
    }


    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountOccupationClassRequest createAccountOccupationClassRequest)
    {
        var result = await _accountOccupationClass.AddAsync(createAccountOccupationClassRequest);
        return Ok(result);
    }


    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountOccupationClassRequest updateOccupationClassOfAccountRequest)
    {
        var result = await _accountOccupationClass.UpdateAsync(updateOccupationClassOfAccountRequest);
        return Ok(result);
    }


    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountOccupationClassRequest deleteOccupationClassOfAccountRequest)
    {
        var result = await _accountOccupationClass.DeleteAsync(deleteOccupationClassOfAccountRequest);
        return Ok(result);
    }
}


