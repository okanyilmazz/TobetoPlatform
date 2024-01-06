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
public class CitiesController : ControllerBase
{
    ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _cityService.GetByIdAsync(id);
        return Ok(result);
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _cityService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CacheRemove("Cities.Get")]
    [CustomValidation(typeof(CreateCityRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCityRequest createCityRequest)
    {
        var result = await _cityService.AddAsync(createCityRequest);
        return Ok(result);
    }

    [CacheRemove("Cities.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCityRequest deleteCityRequest)
    {
        var result = await _cityService.DeleteAsync(deleteCityRequest);
        return Ok(result);
    }

    [CacheRemove("Cities.Get")]
    [CustomValidation(typeof(UpdateCityRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCityRequest updateCityRequest)
    {
        var result = await _cityService.UpdateAsync(updateCityRequest);
        return Ok(result);
    }
}
