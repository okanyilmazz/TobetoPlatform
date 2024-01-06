using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountHomeworkService
{
    Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest);
    Task<UpdatedAccountHomeworkeResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest);
    Task<DeletedAccountHomeworkResponse> DeleteAsync(DeleteAccountHomeworkRequest deleteAccountHomeworkRequest);
    Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountHomeworkResponse> GetByIdAsync(Guid id);
}
