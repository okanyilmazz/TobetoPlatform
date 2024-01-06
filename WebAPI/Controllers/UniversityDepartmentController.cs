using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;


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
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _universityDepartmentService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateUniversityDepartmentRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateUniversityDepartmentRequest createUniversityDepartmentRequest)
    {
        var result = await _universityDepartmentService.AddAsync(createUniversityDepartmentRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateUniversityDepartmentRequestValidator))]
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

