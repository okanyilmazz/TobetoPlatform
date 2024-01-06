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
public class LessonSubTypesController : ControllerBase
{
    ILessonSubTypeService _lessonSubTypeService;

    public LessonSubTypesController(ILessonSubTypeService lessonSubTypeService)
    {
        _lessonSubTypeService = lessonSubTypeService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonSubTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonSubTypeService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("LessonSubTypes.Get")]
    [CustomValidation(typeof(CreateLessonSubTypeRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonSubTypeRequest createLessonSubTypeRequest)
    {
        var result = await _lessonSubTypeService.AddAsync(createLessonSubTypeRequest);
        return Ok(result);
    }

    [CacheRemove("LessonSubTypes.Get")]
    [CustomValidation(typeof(UpdateLessonSubTypeRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonSubTypeRequest updateLessonSubTypeRequest)
    {
        var result = await _lessonSubTypeService.UpdateAsync(updateLessonSubTypeRequest);
        return Ok(result);
    }

    [CacheRemove("LessonSubTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonSubTypeRequest deleteLessonSubTypeRequest)
    {
        var result = await _lessonSubTypeService.DeleteAsync(deleteLessonSubTypeRequest);
        return Ok(result);
    }
}
