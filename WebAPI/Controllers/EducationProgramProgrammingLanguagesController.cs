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
    public class EducationProgramProgrammingLanguagesController : ControllerBase
    {
        IEducationProgramProgrammingLanguageService _educationProgramProgrammingLanguageService;

        public EducationProgramProgrammingLanguagesController(IEducationProgramProgrammingLanguageService educationProgramProgrammingLanguageservice)
        {
            _educationProgramProgrammingLanguageService = educationProgramProgrammingLanguageservice;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _educationProgramProgrammingLanguageService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _educationProgramProgrammingLanguageService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramProgrammingLanguageRequest CreateEducationProgramProgrammingLanguageRequest)
        {
            var result = await _educationProgramProgrammingLanguageService.AddAsync(CreateEducationProgramProgrammingLanguageRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramProgrammingLanguageRequest deleteEducationProgramProgrammingLanguageRequest)
        {
            var result = await _educationProgramProgrammingLanguageService.DeleteAsync(deleteEducationProgramProgrammingLanguageRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest)
        {
            var result = await _educationProgramProgrammingLanguageService.UpdateAsync(updateEducationProgramProgrammingLanguageRequest);
            return Ok(result);
        }
    }
}
