using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class QuestionTypesController : Controller
{
    IQuestionTypeService _questionTypeService;

    public QuestionTypesController(IQuestionTypeService questionTypeService)
    {
        _questionTypeService = questionTypeService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _questionTypeService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateQuestionTypeRequest createQuestionTypeRequest)
    {
        var result = await _questionTypeService.AddAsync(createQuestionTypeRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionTypeRequest updateQuestionTypeRequest)
    {
        var result = await _questionTypeService.UpdateAsync(updateQuestionTypeRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionTypeRequest deleteQuestionTypeRequest)
    {
        var result = await _questionTypeService.DeleteAsync(deleteQuestionTypeRequest);
        return Ok(result);
    }
}

