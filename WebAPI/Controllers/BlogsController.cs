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
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _blogService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateBlogRequest createBlogRequest)
        {
            var result = await _blogService.AddAsync(createBlogRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteBlogRequest deleteBlogRequest)
        {
            var result = await _blogService.DeleteAsync(deleteBlogRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBlogRequest updateBlogRequest)
        {
            var result = await _blogService.UpdateAsync(updateBlogRequest);
            return Ok(result);
        }
    }
}
