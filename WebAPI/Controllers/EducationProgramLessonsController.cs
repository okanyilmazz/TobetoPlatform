using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramLessonsController : ControllerBase
{
    IEducationProgramLessonService _educationProgramLessonService;

    public EducationProgramLessonsController(IEducationProgramLessonService educationProgramLessonService)
    {
        _educationProgramLessonService = educationProgramLessonService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramLessonService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramLessonService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLessonRequest createEducationProgramLessonRequest)
    {
        var result = await _educationProgramLessonService.AddAsync(createEducationProgramLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLessonRequest updateEducationProgramLessonRequest)
    {
        var result = await _educationProgramLessonService.UpdateAsync(updateEducationProgramLessonRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLessons.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramLessonRequest deleteEducationProgramLessonRequest)
    {
        var result = await _educationProgramLessonService.DeleteAsync(deleteEducationProgramLessonRequest);
        return Ok(result);
    }
}
