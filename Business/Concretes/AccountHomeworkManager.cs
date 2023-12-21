using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AccountHomeworkManager : IAccountHomeworkService
    {
        IAccountHomeworkDal _accountHomeworkDal;
        IMapper _mapper;
        public AccountHomeworkManager(IAccountHomeworkDal accountHomeworkDal, IMapper mapper)
        {
            _accountHomeworkDal = accountHomeworkDal;
            _mapper = mapper;
        }

        
        public async Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest)
        {
            AccountHomework accountHomework = _mapper.Map<AccountHomework>(createAccountHomeworkRequest);
            AccountHomework createdAccountHomework = await _accountHomeworkDal.AddAsync(accountHomework);
            CreatedAccountHomeworkResponse createdAccountHomeworkResponse =_mapper.Map<CreatedAccountHomeworkResponse>(createdAccountHomework);
            return createdAccountHomeworkResponse;
        }

        public async Task<DeletedAccountHomeworkResponse> DeleteAsync(DeleteAccountHomeworkRequest deleteAccountHomeworkRequest)
        {
            AccountHomework accountHomework = _mapper.Map<AccountHomework>(deleteAccountHomeworkRequest);
            AccountHomework deletedAccountHomework = await _accountHomeworkDal.DeleteAsync(accountHomework);
            DeletedAccountHomeworkResponse deletedAccountHomeworkeResponse = _mapper.Map<DeletedAccountHomeworkResponse>(deletedAccountHomework);
            return deletedAccountHomeworkeResponse;
        }

        public async Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync()
        {
            var accountHomework = await _accountHomeworkDal.GetListAsync();
            var mappedAccountHomework = _mapper.Map<Paginate<GetListAccountHomeworkResponse>>(accountHomework);
            return mappedAccountHomework;
        }

        public async  Task<UpdatedAccountHomeworkeResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest)
        {
            AccountHomework accountHomework = _mapper.Map<AccountHomework>(updateAccountHomeworkRequest);
            AccountHomework updatedAccountHomework = await _accountHomeworkDal.UpdateAsync(accountHomework);
            UpdatedAccountHomeworkeResponse updatedAccountHomeworkeResponse = _mapper.Map<UpdatedAccountHomeworkeResponse>(updatedAccountHomework);
            return updatedAccountHomeworkeResponse;
        }
    }
}
