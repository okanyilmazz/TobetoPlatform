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
public class LessonsController : ControllerBase
{
    ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync([FromQuery] Guid id)
    {
        var result = await _lessonService.GetByEducationProgramIdAsync(id);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
    {
        var result = await _lessonService.GetByAccountIdAsync(id);
        return Ok(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("Lessons.Get")]
    [CustomValidation(typeof(CreateLessonRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonRequest createLessonRequest)
    {
        var result = await _lessonService.AddAsync(createLessonRequest);
        return Ok(result);
    }

    [CacheRemove("Lessons.Get")]
    [CustomValidation(typeof(UpdateLessonRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonRequest updateLessonRequest)
    {
        var result = await _lessonService.UpdateAsync(updateLessonRequest);
        return Ok(result);
    }

    [CacheRemove("Lessons.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonRequest deleteLessonRequest)
    {
        var result = await _lessonService.DeleteAsync(deleteLessonRequest);
        return Ok(result);
    }
}
