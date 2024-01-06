using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSocialMediaService
{
    Task<CreatedAccountSocialMediaResponse> AddAsync(CreateAccountSocialMediaRequest createAccountSocialMediaRequest);
    Task<UpdatedAccountSocialMediaResponse> UpdateAsync(UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest);
    Task<DeletedAccountSocialMediaResponse> DeleteAsync(DeleteAccountSocialMediaRequest deleteAccountSocialMediaRequest);
    Task<IPaginate<GetListAccountSocialMediaResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountSocialMediaResponse> GetByIdAsync(Guid Id);
}