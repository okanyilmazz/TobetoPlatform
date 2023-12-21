using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _skillService.GetListAsync();
            return Ok(result);
        }     
        [HttpGet("GetBySkillId")]
        public async Task<IActionResult> GetBySkillId(Guid id)
        {
            var result = await _skillService.GetBySkillIdAsync(id);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateSkillRequest createSkillRequest)
        {
            var result = await _skillService.AddAsync(createSkillRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSkillRequest deleteSkillRequest)
        {
            var result = await _skillService.DeleteAsync(deleteSkillRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            var result = await _skillService.UpdateAsync(updateSkillRequest);
            return Ok(result);
        }
    }
}

