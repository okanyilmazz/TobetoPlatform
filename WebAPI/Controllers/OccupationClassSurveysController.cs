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
    public class OccupationClassSurveysController : ControllerBase
    {
        ICityService _occupationClassSurveyService;

        public OccupationClassSurveysController(ICityService occupationClassSurveyservice)
        {
            _occupationClassSurveyService = occupationClassSurveyservice;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _occupationClassSurveyService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCityRequest createOccupationClassSurveyRequest)
        {
            var result = await _occupationClassSurveyService.AddAsync(createOccupationClassSurveyRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCityRequest deleteOccupationClassSurveyRequest)
        {
            var result = await _occupationClassSurveyService.DeleteAsync(deleteOccupationClassSurveyRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCityRequest updateOccupationClassSurveyRequest)
        {
            var result = await _occupationClassSurveyService.UpdateAsync(updateOccupationClassSurveyRequest);
            return Ok(result);
        }
    }
}
