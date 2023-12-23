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
    public class MediaNewsController : ControllerBase
    {
        IMediaNewService _mediaNewService;

        public MediaNewsController(IMediaNewService mediaNewService)
        {
            _mediaNewService = mediaNewService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediaNewService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediaNewService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateMediaNewRequest createMediaNewRequest)
        {
            var result = await _mediaNewService.AddAsync(createMediaNewRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateMediaNewRequest updateMediaNewRequest)
        {
            var result = await _mediaNewService.UpdateAsync(updateMediaNewRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteMediaNewRequest deleteMediaNewRequest)
        {
            var result = await _mediaNewService.DeleteAsync(deleteMediaNewRequest);
            return Ok(result);
        }
    }
}
