using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamQuestionTypesController : ControllerBase
{
    IExamQuestionTypeService _examQuestionTypeService;

    public ExamQuestionTypesController(IExamQuestionTypeService examQuestionTypeService)
    {
        _examQuestionTypeService = examQuestionTypeService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _examQuestionTypeService.GetListAsync();
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examQuestionTypeService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamQuestionTypeRequest createExamQuestionTypesRequest)
    {
        var result = await _examQuestionTypeService.AddAsync(createExamQuestionTypesRequest);
        return Ok(result);
    }

    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest)
    {
        var result = await _examQuestionTypeService.UpdateAsync(updateExamQuestionTypeRequest);
        return Ok(result);
    }

    [CacheRemove("ExamQuestionTypes.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamQuestionTypeRequest deleteExamQuestionTypeRequest)
    {
        var result = await _examQuestionTypeService.DeleteAsync(deleteExamQuestionTypeRequest);
        return Ok(result);
    }
}

