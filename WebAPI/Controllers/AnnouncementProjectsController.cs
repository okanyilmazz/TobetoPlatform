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
public class AnnouncementProjectsController : ControllerBase
{
    IAnnouncementProjectService _announcementProjectService;

    public AnnouncementProjectsController(IAnnouncementProjectService announcementProjectService)
    {
        _announcementProjectService = announcementProjectService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _announcementProjectService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _announcementProjectService.GetByIdAsync(Id);
        return Ok(result);
    }

    [CacheRemove("AnnouncementProjects.Get")]
    [CustomValidation(typeof(CreateAnnouncementProjectRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementProjectRequest createAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.AddAsync(createAnnouncementProjectRequest);
        return Ok(result);
    }

    [CacheRemove("AnnouncementProjects.Get")]
    [CustomValidation(typeof(UpdateAnnouncementProjectRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.UpdateAsync(updateAnnouncementProjectRequest);
        return Ok(result);
    }

    [CacheRemove("AnnouncementProjects.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest)
    {
        var result = await _announcementProjectService.DeleteAsync(deleteAnnouncementProjectRequest);
        return Ok(result);
    }
}
