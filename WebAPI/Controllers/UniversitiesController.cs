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
public class UniversitiesController : ControllerBase
{
    IUniversityService _universityService;

    public UniversitiesController(IUniversityService universityService)
    {
        _universityService = universityService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _universityService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CacheRemove("Universities.Get")]
    [CustomValidation(typeof(CreateUniversityRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateUniversityRequest createUniversityRequest)
    {
        var result = await _universityService.AddAsync(createUniversityRequest);
        return Ok(result);
    }

    [CacheRemove("Universities.Get")]
    [CustomValidation(typeof(UpdateUniversityRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUniversityRequest updateUniversityRequest)
    {
        var result = await _universityService.UpdateAsync(updateUniversityRequest);
        return Ok(result);
    }

    [CacheRemove("Universities.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteUniversityRequest deleteUniversityRequest)
    {
        var result = await _universityService.DeleteAsync(deleteUniversityRequest);
        return Ok(result);
    }
}
