﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _projectService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _projectService.GetByIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateProjectRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProjectRequest createProjectRequest)
    {
        var result = await _projectService.AddAsync(createProjectRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateProjectRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProjectRequest updateProjectRequest)
    {
        var result = await _projectService.UpdateAsync(updateProjectRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProjectRequest deleteProjectRequest)
    {
        var result = await _projectService.DeleteAsync(deleteProjectRequest);
        return Ok(result);
    }
}