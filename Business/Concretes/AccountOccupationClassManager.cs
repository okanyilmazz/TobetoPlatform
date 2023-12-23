using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
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
    public class AccountOccupationClassManager : IAccountOccupationClassService
    {
        IAccountOccupationClassDal _accountOccupationClassDal;
        IMapper _mapper;
        AccountOccupationClassBusinessRules _accountOccupationClassRules;

        public AccountOccupationClassManager(IAccountOccupationClassDal accountOccupationClassDal, IMapper mapper, AccountOccupationClassBusinessRules accountOccupationClassRules)
        {
            _accountOccupationClassDal = accountOccupationClassDal;
            _mapper = mapper;
            _accountOccupationClassRules = accountOccupationClassRules;
        }

        public async Task<CreatedAccountOccupationClassResponse> AddAsync(CreateAccountOccupationClassRequest createAccountOccupationClassRequest)
        {
            AccountOccupationClass AccountOccupationClass = _mapper.Map<AccountOccupationClass>(createAccountOccupationClassRequest);
            AccountOccupationClass addedAccountOccupationClass = await _accountOccupationClassDal.AddAsync(AccountOccupationClass);
            var mappedAccountOccupationClass = _mapper.Map<CreatedAccountOccupationClassResponse>(addedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }

        public async Task<DeletedAccountOccupationClassResponse> DeleteAsync(DeleteAccountOccupationClassRequest deleteAccountOccupationClassRequest)
        {
            await _accountOccupationClassRules.IsExistsAccountOccupationClass(deleteAccountOccupationClassRequest.Id);
            AccountOccupationClass AccountOccupationClass = _mapper.Map<AccountOccupationClass>(deleteAccountOccupationClassRequest);
            AccountOccupationClass deletedAccountOccupationClass = await _accountOccupationClassDal.DeleteAsync(AccountOccupationClass);
            var mappedAccountOccupationClass = _mapper.Map<DeletedAccountOccupationClassResponse>(deletedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }

        public async Task<GetListAccountOccupationClassResponse> GetByIdAsync(Guid id)
        {
            var AccountOccupationClassList = await _accountOccupationClassDal.GetAsync(a=>a.Id == id);
            var mappedAccountOccupationClass = _mapper.Map<GetListAccountOccupationClassResponse>(AccountOccupationClassList);
            return mappedAccountOccupationClass;
        }

        public async Task<IPaginate<GetListAccountOccupationClassResponse>> GetListAsync()
        {
            var AccountOccupationClassList = await _accountOccupationClassDal.GetListAsync();
            var mappedAccountOccupationClass = _mapper.Map<Paginate<GetListAccountOccupationClassResponse>>(AccountOccupationClassList);
            return mappedAccountOccupationClass;
        }

        public async Task<UpdatedAccountOccupationClassResponse> UpdateAsync(UpdateAccountOccupationClassRequest updateAccountOccupationClassRequest)
        {
            await _accountOccupationClassRules.IsExistsAccountOccupationClass(updateAccountOccupationClassRequest.Id);
            AccountOccupationClass AccountOccupationClass = _mapper.Map<AccountOccupationClass>(updateAccountOccupationClassRequest);
            AccountOccupationClass updateedAccountOccupationClass = await _accountOccupationClassDal.UpdateAsync(AccountOccupationClass);
            var mappedAccountOccupationClass = _mapper.Map<UpdatedAccountOccupationClassResponse>(updateedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }
    }
}
