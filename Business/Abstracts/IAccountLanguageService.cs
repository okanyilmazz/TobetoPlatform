using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountLanguageService
{
    Task<CreatedAccountLanguageResponse> AddAsync(CreateAccountLanguageRequest createAccountLanguageRequest);
    Task<UpdatedAccountLanguageResponse> UpdateAsync(UpdateAccountLanguageRequest updateAccountLanguageRequest);
    Task<DeletedAccountLanguageResponse> DeleteAsync(DeleteAccountLanguageRequest deleteAccountLanguageRequest);
    Task<IPaginate<GetListAccountLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountLanguageResponse> GetByIdAsync(Guid id);
}
