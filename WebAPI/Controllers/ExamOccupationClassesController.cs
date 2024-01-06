﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamOccupationClassesController : ControllerBase
{
    IExamOccupationClassService _examOccupationClassService;

    public ExamOccupationClassesController(IExamOccupationClassService examOccupationClassService)
    {
        _examOccupationClassService = examOccupationClassService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _examOccupationClassService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examOccupationClassService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamOccupationClassRequest createExamOccupationClassRequest)
    {
        var result = await _examOccupationClassService.AddAsync(createExamOccupationClassRequest);
        return Ok(result);
    }

    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamOccupationClassRequest updateExamOccupationClassRequest)
    {
        var result = await _examOccupationClassService.UpdateAsync(updateExamOccupationClassRequest);
        return Ok(result);
    }

    [CacheRemove("ExamOccupationClasses.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamOccupationClassRequest deleteExamOccupationClassRequest)
    {
        var result = await _examOccupationClassService.DeleteAsync(deleteExamOccupationClassRequest);
        return Ok(result);
    }
}