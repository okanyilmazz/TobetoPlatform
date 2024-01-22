﻿using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.EducationProgramLevelRequests;

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

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _educationProgramLevelService.GetListAsync();
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLevelRequest createEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.AddAsync(createEducationProgramLevelRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLevelRequest updateEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.UpdateAsync(updateEducationProgramLevelRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLevels.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramLevelRequest deleteEducationProgramLevelRequest)
    {
        var result = await _educationProgramLevelService.DeleteAsync(deleteEducationProgramLevelRequest);
        return Ok(result);
    }
}
