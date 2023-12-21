using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class ExamResultsController : Controller
{
    IExamResultService _examResultService;
    public ExamResultsController(IExamResultService examResultService)
    {
        _examResultService = examResultService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _examResultService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateExamResultRequest createExamResultsRequest)
    {
        var result = await _examResultService.AddAsync(createExamResultsRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateExamResultRequest updateExamResultRequest)
    {
        var result = await _examResultService.UpdateAsync(updateExamResultRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteExamResultRequest deleteExamResultRequest)
    {
        var result = await _examResultService.DeleteAsync(deleteExamResultRequest);
        return Ok(result);
    }
}

