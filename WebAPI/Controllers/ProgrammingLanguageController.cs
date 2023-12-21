using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : ControllerBase
{
    IProgrammingLanguageService _programmingLanguageService;

    public ProgrammingLanguagesController(IProgrammingLanguageService programmingLanguageService)
    {
        _programmingLanguageService = programmingLanguageService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _programmingLanguageService.GetListAsync();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _programmingLanguageService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProgrammingLanguageRequest createProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.AddAsync(createProgrammingLanguageRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.UpdateAsync(updateProgrammingLanguageRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProgrammingLanguageRequest deleteProgrammingLanguageRequest)
    {
        var result = await _programmingLanguageService.DeleteAsync(deleteProgrammingLanguageRequest);
        return Ok(result);
    }
}