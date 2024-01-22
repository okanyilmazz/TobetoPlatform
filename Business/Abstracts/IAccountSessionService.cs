using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;
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