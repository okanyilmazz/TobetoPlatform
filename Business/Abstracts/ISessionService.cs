using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISessionService
    {
        Task<IPaginate<GetListSessionResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListSessionResponse> GetByIdAsync(Guid id);
        Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest);
        Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest);
        Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest);
    }
}
