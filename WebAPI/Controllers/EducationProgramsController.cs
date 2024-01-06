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
public class EducationProgramsController : ControllerBase
{
    IEducationProgramService _educationProgramService;

    public EducationProgramsController(IEducationProgramService EducationProgramService)
    {
        _educationProgramService = EducationProgramService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("GetListByOccupationClassId")]
    public async Task<IActionResult> GetByOccupationClassId([FromQuery] Guid id)
    {
        var result = await _educationProgramService.GetByOccupationClassIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateEducationProgramRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramRequest createEducationProgramRequest)
    {
        var result = await _educationProgramService.AddAsync(createEducationProgramRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateEducationProgramRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramRequest updateEducationProgramRequest)
    {
        var result = await _educationProgramService.UpdateAsync(updateEducationProgramRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramRequest deleteEducationProgramRequest)
    {
        var result = await _educationProgramService.DeleteAsync(deleteEducationProgramRequest);
        return Ok(result);
    }
}
