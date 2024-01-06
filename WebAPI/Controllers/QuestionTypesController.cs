using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionTypesController : Controller
{
    IQuestionTypeService _questionTypeService;

    public QuestionTypesController(IQuestionTypeService questionTypeService)
    {
        _questionTypeService = questionTypeService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _questionTypeService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CacheRemove("QuestionTypes.Get")]
    [CustomValidation(typeof(CreateQuestionTypeRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateQuestionTypeRequest createQuestionTypeRequest)
    {
        var result = await _questionTypeService.AddAsync(createQuestionTypeRequest);
        return Ok(result);
    }

    [CacheRemove("QuestionTypes.Get")]
    [CustomValidation(typeof(UpdateQuestionTypeRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionTypeRequest updateQuestionTypeRequest)
    {
        var result = await _questionTypeService.UpdateAsync(updateQuestionTypeRequest);
        return Ok(result);
    }

    [CacheRemove("QuestionTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionTypeRequest deleteQuestionTypeRequest)
    {
        var result = await _questionTypeService.DeleteAsync(deleteQuestionTypeRequest);
        return Ok(result);
    }
}

