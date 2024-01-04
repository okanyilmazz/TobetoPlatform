using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _questionService.GetListAsync();
        return Ok(result);
    }

    [HttpGet("GetByExamId")]
    public async Task<IActionResult> GetByExamIdAsync(Guid Id)
    {
        var result = await _questionService.GetByExamIdAsync(Id);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _questionService.GetByIdAsync(id);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateQuestionRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateQuestionRequest createQuestionRequest)
    {
        var result = await _questionService.AddAsync(createQuestionRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateQuestionRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionRequest updateQuestionRequest)
    {
        var result = await _questionService.UpdateAsync(updateQuestionRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionRequest deleteQuestionRequest)
    {
        var result = await _questionService.DeleteAsync(deleteQuestionRequest);
        return Ok(result);
    }
}
