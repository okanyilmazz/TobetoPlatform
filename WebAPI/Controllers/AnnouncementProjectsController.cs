using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementProjectsController : ControllerBase
    {
        IAnnouncementProjectService _announcementProjectService;

        public AnnouncementProjectsController(IAnnouncementProjectService announcementProjectService)
        {
            _announcementProjectService = announcementProjectService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _announcementProjectService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementProjectRequest createAnnouncementProjectRequest)
        {
            var result = await _announcementProjectService.AddAsync(createAnnouncementProjectRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest)
        {
            var result = await _announcementProjectService.UpdateAsync(updateAnnouncementProjectRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest)
        {
            var result = await _announcementProjectService.DeleteAsync(deleteAnnouncementProjectRequest);
            return Ok(result);
        }
    }
}
