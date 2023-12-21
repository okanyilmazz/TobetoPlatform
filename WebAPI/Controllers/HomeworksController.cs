using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworksController : ControllerBase
{
    IHomeworkService _homeworkService;

    public HomeworksController(IHomeworkService homeworkService)
    {
        _homeworkService = homeworkService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _homeworkService.GetListAsync();
        return Ok(result);
    }  
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountId(Guid id)
    {
        var result = await _homeworkService.GetByAccountIdAsync(id);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateHomeworkRequest createHomeworkRequest)
    {
        var result = await _homeworkService.AddAsync(createHomeworkRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteHomeworkRequest deleteHomeworkRequest)
    {
        var result = await _homeworkService.DeleteAsync(deleteHomeworkRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateHomeworkRequest updateHomeworkRequest)
    {
        var result = await _homeworkService.UpdateAsync(updateHomeworkRequest);
        return Ok(result);
    }
}

