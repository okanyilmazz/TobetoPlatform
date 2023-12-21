using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramLevelsController : ControllerBase
{
    IEducationProgramLevelService _educationProgramLevelService;

    public EducationProgramLevelsController(IEducationProgramLevelService educationProgramLevelService)
    {
        _educationProgramLevelService = educationProgramLevelService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _educationProgramLevelService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLevelRequest createEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.AddAsync(createEducationProgramLevelRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLevelRequest updateEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.UpdateAsync(updateEducationProgramLevelRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramLevelRequest deleteEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.DeleteAsync(deleteEducationProgramLevelRequest);
        return Ok(result);
    }
}
