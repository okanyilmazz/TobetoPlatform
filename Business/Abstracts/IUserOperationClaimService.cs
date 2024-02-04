using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.UniversityResponses;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserOperationClaimService
    {
        Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest);
        Task<UpdatedUserOperationClaimResponse> UpdateAsync(UpdateUserOperationClaimRequest updateUserOperationClaimRequest);
        Task<DeletedUserOperationClaimResponse> DeleteAsync(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest);
        Task<IPaginate<GetListUserOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    }
}
