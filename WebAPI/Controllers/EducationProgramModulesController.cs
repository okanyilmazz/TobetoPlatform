using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramModuleRequests;
using Business.Rules.ValidationRules.FluentValidation.EducationProgramModuleValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramModulesController : ControllerBase
{
    IEducationProgramModuleService _educationProgramModuleService;

    public EducationProgramModulesController(IEducationProgramModuleService educationProgramModuleService)
    {
        _educationProgramModuleService = educationProgramModuleService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramModuleService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramModuleService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByModuleId")]
    public async Task<IActionResult> GetByModuleIdAsync([FromQuery] Guid moduleId)
    {
        var result = await _educationProgramModuleService.GetByModuleIdAsync(moduleId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync([FromQuery] Guid educationProgramId)
    {
        var result = await _educationProgramModuleService.GetByEducationProgramIdAsync(educationProgramId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramModules.Get")]
    [CustomValidation(typeof(CreateEducationProgramModuleRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramModuleRequest createEducationProgramModuleRequest)
    {
        var result = await _educationProgramModuleService.AddAsync(createEducationProgramModuleRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramModules.Get")]
    [CustomValidation(typeof(UpdateEducationProgramModuleRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramModuleRequest updateEducationProgramModuleRequest)
    {
        var result = await _educationProgramModuleService.UpdateAsync(updateEducationProgramModuleRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramModules.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest)
    {
        var result = await _educationProgramModuleService.DeleteAsync(deleteEducationProgramModuleRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramModules.Get")]
    [HttpPost("DeleteByModuleIdAndEducationProgramId")]
    public async Task<IActionResult> DeleteByModuleIdAndEducationProgramIdAsync([FromBody] DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest)
    {
        var result = await _educationProgramModuleService.DeleteByModuleIdAndEducationProgramIdAsync(deleteEducationProgramModuleRequest);
        return Ok(result);
    }
}
