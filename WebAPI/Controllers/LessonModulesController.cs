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
public class LessonModulesController : ControllerBase
{
    ILessonModuleService _lessonModuleService;

    public LessonModulesController(ILessonModuleService lessonsModuleService)  
    {
        _lessonModuleService = lessonsModuleService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonModuleService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonModuleService.GetByIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateLessonModuleRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonModuleRequest createLessonModuleRequest)
    {
        var result = await _lessonModuleService.AddAsync(createLessonModuleRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateLessonModuleRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonModuleRequest updateLessonModuleRequest)
    {
        var result = await _lessonModuleService.UpdateAsync(updateLessonModuleRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonModuleRequest deleteLessonModuleRequest)
    {
        var result = await _lessonModuleService.DeleteAsync(deleteLessonModuleRequest);
        return Ok();
    }
}
