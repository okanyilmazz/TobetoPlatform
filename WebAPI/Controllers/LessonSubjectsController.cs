using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Rules.ValidationRules.FluentValidation.LessonSubjectValidators;
using Business.Dtos.Requests.LessonSubjectRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonSubjectsController : ControllerBase
{
    ILessonSubjectService _lessonSubjectService;

    public LessonSubjectsController(ILessonSubjectService lessonSubjectService)
    {
        _lessonSubjectService = lessonSubjectService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonSubjectService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonSubjectService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonSubjects.Get")]
    [CustomValidation(typeof(CreateLessonSubjectRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonSubjectRequest createLessonSubjectRequest)
    {
        var result = await _lessonSubjectService.AddAsync(createLessonSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonSubjects.Get")]
    [CustomValidation(typeof(UpdateLessonSubjectRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonSubjectRequest updateLessonSubjectRequest)
    {
        var result = await _lessonSubjectService.UpdateAsync(updateLessonSubjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonSubjects.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync(DeleteLessonSubjectRequest deleteLessonSubjectRequest)
    {
        var result = await _lessonSubjectService.DeleteAsync(deleteLessonSubjectRequest);
        return Ok(result);
    }
}
