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
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AccountSkillManager : IAccountSkillService
    {
        IAccountSkillDal _accountSkillDal;
        IMapper _mapper;
        AccountSkillBusinessRules _accountSkillBusinessRules;

        public AccountSkillManager(IAccountSkillDal accountSkillDal, IMapper mapper, AccountSkillBusinessRules accountSkillBusinessRules)
        {
            _accountSkillDal = accountSkillDal;
            _mapper = mapper;
            _accountSkillBusinessRules = accountSkillBusinessRules;
        }
        public async Task<CreatedAccountSkillResponse> AddAsync(CreateAccountSkillRequest createAccountSkillRequest)
        {
            AccountSkill accountSkill = _mapper.Map<AccountSkill>(createAccountSkillRequest);
            AccountSkill addedAccountSkill = await _accountSkillDal.AddAsync(accountSkill);
            CreatedAccountSkillResponse createdAccountSkillResponse = _mapper.Map<CreatedAccountSkillResponse>(addedAccountSkill);
            return createdAccountSkillResponse;
        }

        public async Task<DeletedAccountSkillResponse> DeleteAsync(DeleteAccountSkillRequest deleteAccountSkillRequest)
        {
            await _accountSkillBusinessRules.IsExistsAccountSkill(deleteAccountSkillRequest.Id);
            AccountSkill accountSkill = _mapper.Map<AccountSkill>(deleteAccountSkillRequest);
            AccountSkill deletedAccountSkill = await _accountSkillDal.DeleteAsync(accountSkill);
            DeletedAccountSkillResponse deletedAccountSkillResponse = _mapper.Map<DeletedAccountSkillResponse>(deletedAccountSkill);
            return deletedAccountSkillResponse;
        }

        public async Task<IPaginate<GetListAccountSkillResponse>> GetListAsync()
        {
            var accountSkills = await _accountSkillDal.GetListAsync();
            var mappedAccountSkills = _mapper.Map<Paginate<GetListAccountSkillResponse>>(accountSkills);
            return mappedAccountSkills;
        }

        public async Task<UpdatedAccountSkillResponse> UpdateAsync(UpdateAccountSkillRequest updateAccountSkillRequest)
        {
            await _accountSkillBusinessRules.IsExistsAccountSkill(updateAccountSkillRequest.Id);
            AccountSkill accountSkill = _mapper.Map<AccountSkill>(updateAccountSkillRequest);
            AccountSkill updatedAccountSkill = await _accountSkillDal.UpdateAsync(accountSkill);
            UpdatedAccountSkillResponse updatedAccountSkillResponse = _mapper.Map<UpdatedAccountSkillResponse>(updatedAccountSkill);
            return updatedAccountSkillResponse;
        }
    }
}