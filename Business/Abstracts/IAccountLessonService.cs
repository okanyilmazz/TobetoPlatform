using Business.Dtos.Requests.AccountLessonRequests;
using Business.Dtos.Responses.AccountLessonResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IAccountLessonService
{
    Task<CreatedAccountLessonResponse> AddAsync(CreateAccountLessonRequest createLessonOfAccountRequest);
    Task<UpdatedAccountLessonResponse> UpdateAsync(UpdateAccountLessonRequest updateLessonOfAccountRequest);
    Task<DeletedAccountLessonResponse> DeleteAsync(DeleteAccountLessonRequest deleteLessonOfAccountRequest);
    Task<IPaginate<GetListAccountLessonResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountLessonResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListAccountLessonResponse>> GetByAccountIdAsync(Guid accountId);
    Task<GetListAccountLessonResponse> GetByAccountIdAndLessonIdAsync(Guid accountId,Guid lessonId);
}