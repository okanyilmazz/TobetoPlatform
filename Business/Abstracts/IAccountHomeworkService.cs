using AutoMapper;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAccountHomeworkService
    {
        Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest);
        Task<UpdatedAccountHomeworkeResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest);
        Task<DeletedAccountHomeworkResponse> DeleteAsync(DeleteAccountHomeworkRequest deleteAccountHomeworkRequest);
        Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync();
        Task<GetListAccountHomeworkResponse> GetByIdAsync(Guid id);

    }
}
