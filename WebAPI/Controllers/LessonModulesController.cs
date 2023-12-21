using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
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
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _lessonModuleService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonModuleRequest createLessonModuleRequest)
    {
        var result = await _lessonModuleService.AddAsync(createLessonModuleRequest);
        return Ok(result);
    }

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
