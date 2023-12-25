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
using Castle.Components.DictionaryAdapter.Xml;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AccountManager : IAccountService
    {

        IAccountDal _accountDal;

        IMapper _mapper;
        AccountBusinessRules _accountBusinessRules;

        public AccountManager(IAccountDal accountDal, IMapper mapper, AccountBusinessRules accountBusinessRules)
        {
            _accountDal = accountDal;
            _mapper = mapper;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest)
        {
            Account account = _mapper.Map<Account>(createAccountRequest);
            Account addedAccount = await _accountDal.AddAsync(account);
            CreatedAccountResponse createdAccountResponse = _mapper.Map<CreatedAccountResponse>(addedAccount);
            return createdAccountResponse;
        }

        public async Task<DeletedAccountResponse> DeleteAsync(DeleteAccountRequest deleteAccountRequest)
        {
            await _accountBusinessRules.IsExistsAccount(deleteAccountRequest.Id);
            Account account = await _accountDal.GetAsync(predicate: l => l.Id == deleteAccountRequest.Id);
            Account deletedAccount = await _accountDal.DeleteAsync(account);
            DeletedAccountResponse deletedAccountResponse = _mapper.Map<DeletedAccountResponse>(deletedAccount);
            return deletedAccountResponse;
        }

        public async Task<IPaginate<GetListAccountResponse>> GetBySessionIdAsync(Guid sessionId)
        {
            var accountList = await _accountDal.GetListAsync(
                 include: e => e.Include(s => s.AccountSessions).ThenInclude(ask => ask.Session));

            var filteredAccounts = accountList
                .Items.Where(e => e.AccountSessions.Any(s => s.SessionId == sessionId)).ToList();

            var mappedAccounts = _mapper.Map<Paginate<GetListAccountResponse>>(filteredAccounts);
            return mappedAccounts;
        }

        public async Task<IPaginate<GetListAccountResponse>> GetListAsync()
        {
            var account = await _accountDal.GetListAsync();
            var mappedAccountSession = _mapper.Map<Paginate<GetListAccountResponse>>(account);
            return mappedAccountSession;
        }

        public async Task<GetListAccountResponse> GetByIdAsync(Guid id)
        {
            var account = await _accountDal.GetAsync(a => a.Id == id);
            var mappedAccount = _mapper.Map<GetListAccountResponse>(account);
            return mappedAccount;
        }

        public async Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest)
        {
            await _accountBusinessRules.IsExistsAccount(updateAccountRequest.Id);
            Account account = _mapper.Map<Account>(updateAccountRequest);
            Account updatedAccount = await _accountDal.UpdateAsync(account);
            UpdatedAccountResponse updatedAccountResponse = _mapper.Map<UpdatedAccountResponse>(updatedAccount);
            return updatedAccountResponse;
        }
    }
}