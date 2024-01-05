using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountService
{
    Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest);
    Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest);
    Task<DeletedAccountResponse> DeleteAsync(DeleteAccountRequest deleteAccountRequest);
    Task<IPaginate<GetListAccountResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountResponse>> GetBySessionIdAsync(Guid id);
    Task<GetListAccountResponse> GetByIdAsync(Guid id);
}
