using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramOccupationClassesController : ControllerBase
{
    IEducationProgramOccupationClassService _educationProgramOccupationClassService;

    public EducationProgramOccupationClassesController(IEducationProgramOccupationClassService educationProgramOccupationClassService)
    {
        _educationProgramOccupationClassService = educationProgramOccupationClassService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramOccupationClassService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramOccupationClassService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest)
    {
        var result = await _educationProgramOccupationClassService.AddAsync(createEducationProgramOccupationClassRequest);
        return Ok(result);
    }

    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramOccupationClassRequest deleteEducationProgramOccupationClassRequest)
    {
        var result = await _educationProgramOccupationClassService.DeleteAsync(deleteEducationProgramOccupationClassRequest);
        return Ok(result);
    }

    [CacheRemove("EducationProgramOccupationClasses.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest)
    {
        var result = await _educationProgramOccupationClassService.UpdateAsync(updateEducationProgramOccupationClassRequest);
        return Ok(result);
    }
}
