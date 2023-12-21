using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageLevelsController : ControllerBase
{
    ILanguageLevelService _languageLevelService;

    public LanguageLevelsController(ILanguageLevelService languageLevelService)
    {
        _languageLevelService = languageLevelService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _languageLevelService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLanguageLevelRequest createLanguageLevelRequest)
    {
        var result = await _languageLevelService.AddAsync(createLanguageLevelRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLanguageLevelRequest updateProjectRequest)
    {
        var result = await _languageLevelService.UpdateAsync(updateProjectRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLanguageLevelRequest deleteProjectRequest)
    {
        var result = await _languageLevelService.DeleteAsync(deleteProjectRequest);
        return Ok(result);
    }
}