using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkExperiencesController : ControllerBase
{
    IWorkExperienceService _workExperienceService;

    public WorkExperiencesController(IWorkExperienceService examService)
    {
        _workExperienceService = examService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _workExperienceService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateWorkExperienceRequest createWorkExperienceRequest)
    {
        var result = await _workExperienceService.AddAsync(createWorkExperienceRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkExperienceRequest updateWorkExperienceRequest)
    {
        var result = await _workExperienceService.UpdateAsync(updateWorkExperienceRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteWorkExperienceRequest deleteWorkExperienceRequest)
    {
        var result = await _workExperienceService.DeleteAsync(deleteWorkExperienceRequest);
        return Ok(result);
    }
}
