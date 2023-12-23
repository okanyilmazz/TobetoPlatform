using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonCategoriesController : ControllerBase
{
    ILessonCategoryService _lessonCategoryService;

    public LessonCategoriesController(ILessonCategoryService lessonCategoryService)
    {
        _lessonCategoryService = lessonCategoryService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _lessonCategoryService.GetListAsync();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonCategoryService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonCategoryRequest createLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.AddAsync(createLessonCategoryRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonCategoryRequest updateLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.UpdateAsync(updateLessonCategoryRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonCategoryRequest deleteLessonCategoryRequest)
    {
        var result = await _lessonCategoryService.DeleteAsync(deleteLessonCategoryRequest);
        return Ok(result);
    }
}
