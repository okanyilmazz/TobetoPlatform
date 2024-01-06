using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamResultsController : Controller
{
    IExamResultService _examResultService;
    public ExamResultsController(IExamResultService examResultService)
    {
        _examResultService = examResultService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _examResultService.GetListAsync();
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examResultService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamResults.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamResultRequest createExamResultsRequest)
    {
        var result = await _examResultService.AddAsync(createExamResultsRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamResults.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamResultRequest updateExamResultRequest)
    {
        var result = await _examResultService.UpdateAsync(updateExamResultRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ExamResults.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamResultRequest deleteExamResultRequest)
    {
        var result = await _examResultService.DeleteAsync(deleteExamResultRequest);
        return Ok(result);
    }
}

