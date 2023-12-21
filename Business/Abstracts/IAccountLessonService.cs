using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
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
    Task<IPaginate<GetListAccountLessonResponse>> GetListAsync();
}