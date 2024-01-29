using Business.Abstracts;
using Business.Dtos.Requests.BlogRequests;
using Business.Rules.ValidationRules.FluentValidation.BlogValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Core.CrossCuttingConcerns.Validation;
using Business.Rules.ValidationRules.FluentValidation.CalendarSessionValidators;
using Business.Dtos.Requests.CalendarSessionRequests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarSessionsController : ControllerBase
    {
        ICalendarSessionService _calendarSessionService;

        public CalendarSessionsController(ICalendarSessionService calendarSessionService)
        {
            _calendarSessionService = calendarSessionService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _calendarSessionService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CalendarSessions.Get")]
        [CustomValidation(typeof(CreateCalendarSessionRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCalendarSessionRequest createCalendarSessionRequest)
        {
            var result = await _calendarSessionService.AddAsync(createCalendarSessionRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CalendarSessions.Get")]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCalendarSessionRequest deleteCalendarSessionRequest)
        {
            var result = await _calendarSessionService.DeleteAsync(deleteCalendarSessionRequest);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("CalendarSessions.Get")]
        [CustomValidation(typeof(UpdateCalendarSessionRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCalendarSessionRequest updateCalendarSessionRequest)
        {
            var result = await _calendarSessionService.UpdateAsync(updateCalendarSessionRequest);
            return Ok(result);
        }
    }
}
