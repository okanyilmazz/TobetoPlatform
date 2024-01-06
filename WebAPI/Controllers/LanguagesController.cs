using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _languageService.GetListAsync();
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _languageService.GetByIdAsync(id);
        return Ok(result);
    }

    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid id)
    {
        var result = await _languageService.GetByAccountIdAsync(id);
        return Ok(result);
    }

    [CacheRemove("Languages.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLanguageRequest createLanguageRequest)
    {
        var result = await _languageService.AddAsync(createLanguageRequest);
        return Ok(result);
    }

    [CacheRemove("Languages.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLanguageRequest updateLanguageRequest)
    {
        var result = await _languageService.UpdateAsync(updateLanguageRequest);
        return Ok(result);
    }

    [CacheRemove("Languages.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLanguageRequest deleteLanguageRequest)
    {
        var result = await _languageService.DeleteAsync(deleteLanguageRequest);
        return Ok(result);
    }
}
