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
public class ProgrammingLanguagesController : ControllerBase
{
    IProgrammingLanguageService _programmingLanguageService;

    public ProgrammingLanguagesController(IProgrammingLanguageService programmingLanguageService)
    {
        _programmingLanguageService = programmingLanguageService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _programmingLanguageService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _programmingLanguageService.GetByIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateProgrammingLanguageRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProgrammingLanguageRequest createProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.AddAsync(createProgrammingLanguageRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateProgrammingLanguageRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.UpdateAsync(updateProgrammingLanguageRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProgrammingLanguageRequest deleteProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.DeleteAsync(deleteProgrammingLanguageRequest);
        return Ok(result);
    }
}