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
    public interface IAccountService
    {

        Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest);
        Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest);
        Task<DeletedAccountResponse> DeleteAsync(DeleteAccountRequest deleteAccountRequest);
        Task<IPaginate<GetListAccountResponse>> GetListAsync();
        Task<IPaginate<GetListAccountResponse>> GetBySessionIdAsync(Guid id);        
    }
}
