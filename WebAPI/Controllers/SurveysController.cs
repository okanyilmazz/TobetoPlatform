﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController : ControllerBase
{
    ISurveyService _surveyService;

    public SurveysController(ISurveyService examService)
    {
        _surveyService = examService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _surveyService.GetListAsync();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _surveyService.GetByIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateSurveyRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateSurveyRequest createSurveyRequest)
    {
        var result = await _surveyService.AddAsync(createSurveyRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateSurveyRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSurveyRequest updateSurveyRequest)
    {
        var result = await _surveyService.UpdateAsync(updateSurveyRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteSurveyRequest deleteSurveyRequest)
    {
        var result = await _surveyService.DeleteAsync(deleteSurveyRequest);
        return Ok(result);
    }
}
