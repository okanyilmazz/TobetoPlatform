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

namespace Business.Abstracts
{
    public interface IAccountUniversityService
    {
        Task<CreatedAccountUniversityResponse> AddAsync(CreateAccountUniversityRequest createAccountUniversityRequest);
        Task<UpdatedAccountUniversityResponse> UpdateAsync(UpdateAccountUniversityRequest updateAccountUniversityRequest);
        Task<DeletedAccountUniversityResponse> DeleteAsync(DeleteAccountUniversityRequest deleteAccountUniversityRequest);

        Task<IPaginate<GetListAccountUniversityResponse>> GetListAsync();
        Task<GetListAccountUniversityResponse> GetByIdAsync(Guid Id);

    }
}
