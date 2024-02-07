using Business.Abstracts;
using Business.Dtos.Requests.BlogRequests;
using Business.Rules.ValidationRules.FluentValidation.BlogValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Core.CrossCuttingConcerns.Validation;
using Business.Dtos.Requests.InstructorRequests;
using Business.Rules.ValidationRules.FluentValidation.InstructorValidators;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorsService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorsService = instructorService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _instructorsService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("Instructors.Get")]
        [CustomValidation(typeof(CreateInstructorRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateInstructorRequest createCalendarSessionRequest)
        {
            var result = await _instructorsService.AddAsync(createCalendarSessionRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CalendarSessions.Get")]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteInstructorRequest deleteInstructorsRequest)
        {
            var result = await _instructorsService.DeleteAsync(deleteInstructorsRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CalendarSessions.Get")]
        [CustomValidation(typeof(UpdateInstructorRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorsService.UpdateAsync(updateInstructorRequest);
            return Ok(result);
        }
    }
}
