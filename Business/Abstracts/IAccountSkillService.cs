using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IAccountSkillService
    {
        Task<CreatedAccountSkillResponse> AddAsync(CreateAccountSkillRequest createAccountSkillRequest);
        Task<UpdatedAccountSkillResponse> UpdateAsync(UpdateAccountSkillRequest updateAccountSkillRequest);
        Task<DeletedAccountSkillResponse> DeleteAsync(DeleteAccountSkillRequest deleteAccountSkillRequest);
        Task<IPaginate<GetListAccountSkillResponse>> GetListAsync();
    }
}
