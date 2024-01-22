using Business.Dtos.Requests.AccountSkillRequests;
using Business.Dtos.Responses.AccountSkillResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSkillService
{
    Task<CreatedAccountSkillResponse> AddAsync(CreateAccountSkillRequest createAccountSkillRequest);
    Task<UpdatedAccountSkillResponse> UpdateAsync(UpdateAccountSkillRequest updateAccountSkillRequest);
    Task<DeletedAccountSkillResponse> DeleteAsync(DeleteAccountSkillRequest deleteAccountSkillRequest);
    Task<IPaginate<GetListAccountSkillResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountSkillResponse> GetByIdAsync(Guid id);
}