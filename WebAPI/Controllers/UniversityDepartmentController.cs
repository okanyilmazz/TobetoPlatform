using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class UniversityDepartmentsController : Controller
{
    IUniversityDepartmentService _universityDepartmentService;

    public UniversityDepartmentsController(IUniversityDepartmentService universityDepartmentService)
    {
        _universityDepartmentService = universityDepartmentService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _universityDepartmentService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateUniversityDepartmentRequest createUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.AddAsync(createUniversityDepartmentRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.UpdateAsync(updateUniversityDepartmentRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.DeleteAsync(deleteUniversityDepartmentRequest);
        return Ok(result);
    }
}

