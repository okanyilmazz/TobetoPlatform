using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSessionService
{
    Task<CreatedAccountSessionResponse> AddAsync(CreateAccountSessionRequest createAccountSessionRequest);
    Task<UpdatedAccountSessionResponse> UpdateAsync(UpdateAccountSessionRequest updateAccountSessionRequest);
    Task<DeletedAccountSessionResponse> DeleteAsync(DeleteAccountSessionRequest deleteAccountSessionRequest);
    Task<IPaginate<GetListAccountSessionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountSessionResponse> GetByIdAsync(Guid id);
}