using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _skillService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _skillService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
    {
        var result = await _skillService.GetByAccountIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("Skills.Get")]
    [CustomValidation(typeof(CreateSkillRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateSkillRequest createSkillRequest)
    {
        var result = await _skillService.AddAsync(createSkillRequest);
        return Ok(result);
    }

    [CacheRemove("Skills.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteSkillRequest deleteSkillRequest)
    {
        var result = await _skillService.DeleteAsync(deleteSkillRequest);
        return Ok(result);
    }

    [CacheRemove("Skills.Get")]
    [CustomValidation(typeof(UpdateSkillRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSkillRequest updateSkillRequest)
    {
        var result = await _skillService.UpdateAsync(updateSkillRequest);
        return Ok(result);
    }
}