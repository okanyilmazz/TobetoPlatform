using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Requests.CalendarSessionRequests;
using Business.Dtos.Responses.BlogResponses;
using Business.Dtos.Responses.CalendarSessionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICalendarSessionService
    {
        Task<CreatedCalendarSessionResponse> AddAsync(CreateCalendarSessionRequest createCalendarSessionRequest);
        Task<UpdatedCalendarSessionResponse> UpdateAsync(UpdateCalendarSessionRequest updateCalendarSessionRequest);
        Task<DeletedCalendarSessionResponse> DeleteAsync(DeleteCalendarSessionRequest deleteCalendarSessionRequest);
        Task<IPaginate<GetListCalendarSessionResponse>> GetListAsync(PageRequest pageRequest);
        //Task<IPaginate<GetListCalendarSessionResponse>> GetByUserOperationClaimIdAsync(Guid? id);
    }
}
