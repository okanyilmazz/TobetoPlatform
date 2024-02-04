using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CalendarSessionRequests;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.CalendarSessionResponses;
using Business.Dtos.Responses.OccupationResponses;
using Business.Dtos.Responses.SessionResponses;
using Business.Dtos.Responses.UserResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CalendarSessionManager : ICalendarSessionService
    {
        ICalendarSessionDal _calendarSessionDal;
        IMapper _mapper;
        CalenderSessionBusinessRules _calendarSessionBusinessRules;

        public CalendarSessionManager(ICalendarSessionDal calendarSessionDal, IMapper mapper, CalenderSessionBusinessRules calendarSessionBusinessRules)
        {
            _calendarSessionDal = calendarSessionDal;
            _mapper = mapper;
            _calendarSessionBusinessRules = calendarSessionBusinessRules;
        }

        public async Task<CreatedCalendarSessionResponse> AddAsync(CreateCalendarSessionRequest createCalendarSessionRequest)
        {
            CalendarSession calendarSession = _mapper.Map<CalendarSession>(createCalendarSessionRequest);
            CalendarSession createdCalendarSession = await _calendarSessionDal.AddAsync(calendarSession);
            CreatedCalendarSessionResponse createdCalendarSessionResponse = _mapper.Map<CreatedCalendarSessionResponse>(createdCalendarSession);
            return createdCalendarSessionResponse;
        }

        public async Task<DeletedCalendarSessionResponse> DeleteAsync(DeleteCalendarSessionRequest deleteCalendarSessionRequest)
        {
            CalendarSession calendarSession = _mapper.Map<CalendarSession>(deleteCalendarSessionRequest);
            CalendarSession deletedCalendarSession = await _calendarSessionDal.DeleteAsync(calendarSession);
            DeletedCalendarSessionResponse deletedCalendarSessionResponse = _mapper.Map<DeletedCalendarSessionResponse>(deletedCalendarSession);
            return deletedCalendarSessionResponse;
        }

        public async Task<IPaginate<GetListCalendarSessionResponse>> GetListAsync(PageRequest pageRequest)
        {
            var calendarSession = await _calendarSessionDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize,
                include: u => u
                .Include(u => u.Session)
                .Include(u => u.UserOperationClaim)
                );

            var mappedSession = _mapper.Map<Paginate<GetListCalendarSessionResponse>>(calendarSession);
            return mappedSession;
        }

        public async Task<UpdatedCalendarSessionResponse> UpdateAsync(UpdateCalendarSessionRequest updateCalendarSessionRequest)
        {
            CalendarSession calendarSession = _mapper.Map<CalendarSession>(updateCalendarSessionRequest);
            CalendarSession updatedCalendarSession = await _calendarSessionDal.UpdateAsync(calendarSession);
            UpdatedCalendarSessionResponse updatedCalendarSessionResponse = _mapper.Map<UpdatedCalendarSessionResponse>(updatedCalendarSession);
            return updatedCalendarSessionResponse;
        }
    }
}
