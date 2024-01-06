using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamQuestionsController : ControllerBase
{
    IExamQuestionService _examQuestionService;

    public ExamQuestionsController(IExamQuestionService examQuestionService)
    {
        _examQuestionService = examQuestionService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _examQuestionService.GetListAsync();
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examQuestionService.GetByIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("ExamQuestions.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamQuestionRequest createExamQuestionRequest)
    {
        var result = await _examQuestionService.AddAsync(createExamQuestionRequest);
        return Ok(result);
    }

    [CacheRemove("ExamQuestions.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamQuestionRequest updateExamQuestionRequest)
    {
        var result = await _examQuestionService.UpdateAsync(updateExamQuestionRequest);
        return Ok(result);
    }

    [CacheRemove("ExamQuestions.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamQuestionRequest deleteExamQuestionRequest)
    {
        var result = await _examQuestionService.DeleteAsync(deleteExamQuestionRequest);
        return Ok(result);
    }
}
