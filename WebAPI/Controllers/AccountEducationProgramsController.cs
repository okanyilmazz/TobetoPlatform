using Business.Abstracts;
using Business.Dtos.Requests.AccountEducationProgramRequests;
using Business.Rules.ValidationRules.FluentValidation.AccountEducationProgramValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountEducationProgramsController : ControllerBase
{
    IAccountEducationProgramService _accountAccountEducationProgramsService;

    public AccountEducationProgramsController(IAccountEducationProgramService accountAccountEducationProgramsService)
    {
        _accountAccountEducationProgramsService = accountAccountEducationProgramsService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _accountAccountEducationProgramsService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountAccountEducationProgramsService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountEducationPrograms.Get")]
    [CustomValidation(typeof(CreateAccountEducationProgramRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountEducationProgramRequest createAccountEducationProgramRequest)
    {
        var result = await _accountAccountEducationProgramsService.AddAsync(createAccountEducationProgramRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountEducationPrograms.Get")]
    [CustomValidation(typeof(UpdateAccountEducationProgramRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountEducationProgramRequest updateAccountEducationProgramRequest)
    {
        var result = await _accountAccountEducationProgramsService.UpdateAsync(updateAccountEducationProgramRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("AccountEducationPrograms.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountEducationProgramRequest deleteAccountEducationProgramRequest)
    {
        var result = await _accountAccountEducationProgramsService.DeleteAsync(deleteAccountEducationProgramRequest);
        return Ok(result);
    }
}
