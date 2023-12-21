using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DegreeTypesController : ControllerBase
{

    IDegreeTypeService _degreeTypeService;

    public DegreeTypesController(IDegreeTypeService degreeTypeservice)
    {
        _degreeTypeService = degreeTypeservice;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _degreeTypeService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateDegreeTypeRequest createDegreeTypeRequest)
    {
        var result = await _degreeTypeService.AddAsync(createDegreeTypeRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteDegreeTypeRequest deleteDegreeTypeRequest)
    {
        var result = await _degreeTypeService.DeleteAsync(deleteDegreeTypeRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateDegreeTypeRequest updateDegreeTypeRequest)
    {
        var result = await _degreeTypeService.UpdateAsync(updateDegreeTypeRequest);
        return Ok(result);
    }
}

