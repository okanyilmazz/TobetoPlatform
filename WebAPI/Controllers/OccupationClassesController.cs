using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationClassesController : ControllerBase
    {
        IOccupationClassService _occupationClassService;

        public OccupationClassesController(IOccupationClassService occupationClassService)
        {
            _occupationClassService = occupationClassService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _occupationClassService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _occupationClassService.GetByIdAsync(id);
            return Ok(result);
        }

        [CustomValidation(typeof(CreateOccupationClassRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOccupationClassRequest createOccupationClassRequest)
        {
            var result = await _occupationClassService.AddAsync(createOccupationClassRequest);
            return Ok(result);
        }

        [CustomValidation(typeof(UpdateOccupationClassRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOccupationClassRequest updateOccupationClassRequest)
        {
            var result = await _occupationClassService.UpdateAsync(updateOccupationClassRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOccupationClassRequest deleteOccupationClassRequest)
        {
            var result = await _occupationClassService.DeleteAsync(deleteOccupationClassRequest);
            return Ok(result);
        }
    }
}
