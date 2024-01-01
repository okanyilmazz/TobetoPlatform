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
using Microsoft.EntityFrameworkCore;
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
            AccountOccupationClass accountOccupationClass = _mapper.Map<AccountOccupationClass>(createAccountOccupationClassRequest);
            AccountOccupationClass addedAccountOccupationClass = await _accountOccupationClassDal.AddAsync(accountOccupationClass);
            var mappedAccountOccupationClass = _mapper.Map<CreatedAccountOccupationClassResponse>(addedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }

        public async Task<DeletedAccountOccupationClassResponse> DeleteAsync(DeleteAccountOccupationClassRequest deleteAccountOccupationClassRequest)
        {
            await _accountOccupationClassRules.IsExistsAccountOccupationClass(deleteAccountOccupationClassRequest.Id);
            AccountOccupationClass accountOccupationClass = await _accountOccupationClassDal.GetAsync(predicate: a => a.Id == deleteAccountOccupationClassRequest.Id);
            AccountOccupationClass deletedAccountOccupationClass = await _accountOccupationClassDal.DeleteAsync(accountOccupationClass, false);
            var mappedAccountOccupationClass = _mapper.Map<DeletedAccountOccupationClassResponse>(deletedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }

        public async Task<GetListAccountOccupationClassResponse> GetByIdAsync(Guid id)
        {
            var accountOccupationClassList = await _accountOccupationClassDal.GetAsync(
                predicate: a => a.Id == id,
                include: aoc => aoc.
                Include(aoc => aoc.OccupationClass)
                .Include(aoc => aoc.Account).ThenInclude(a => a.User));
            var mappedAccountOccupationClass = _mapper.Map<GetListAccountOccupationClassResponse>(accountOccupationClassList);
            return mappedAccountOccupationClass;
        }

        public async Task<IPaginate<GetListAccountOccupationClassResponse>> GetListAsync()
        {
            var accountOccupationClassList = await _accountOccupationClassDal.GetListAsync(
                include: aoc => aoc.
                Include(aoc => aoc.OccupationClass)
                .Include(aoc => aoc.Account).ThenInclude(a => a.User)
                );
            var mappedAccountOccupationClass = _mapper.Map<Paginate<GetListAccountOccupationClassResponse>>(accountOccupationClassList);
            return mappedAccountOccupationClass;
        }

        public async Task<UpdatedAccountOccupationClassResponse> UpdateAsync(UpdateAccountOccupationClassRequest updateAccountOccupationClassRequest)
        {
            await _accountOccupationClassRules.IsExistsAccountOccupationClass(updateAccountOccupationClassRequest.Id);
            AccountOccupationClass accountOccupationClass = _mapper.Map<AccountOccupationClass>(updateAccountOccupationClassRequest);
            AccountOccupationClass updateedAccountOccupationClass = await _accountOccupationClassDal.UpdateAsync(accountOccupationClass);
            var mappedAccountOccupationClass = _mapper.Map<UpdatedAccountOccupationClassResponse>(updateedAccountOccupationClass);
            return mappedAccountOccupationClass;
        }
    }
}
