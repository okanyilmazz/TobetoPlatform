using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SocialMediasController : ControllerBase
    {
        ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _socialMediaService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
        {
            var result = await _socialMediaService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetByAccountId")]
        public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid id)
        {
            var result = await _socialMediaService.GetByAccountIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateSocialMediaRequest createSocialMediaRequest)
        {
            var result = await _socialMediaService.AddAsync(createSocialMediaRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSocialMediaRequest deleteSocialMediaRequest)
        {
            var result = await _socialMediaService.DeleteAsync(deleteSocialMediaRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSocialMediaRequest updateSocialMediaRequest)
        {
            var result = await _socialMediaService.UpdateAsync(updateSocialMediaRequest);
            return Ok(result);
        }
    }
}


