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
    public class AccountSessionManager : IAccountSessionService
    {
        IAccountSessionDal _accountSessionDal;
        IMapper _mapper;
        AccountSessionBusinessRules _accountSessionBusinessRules;

        public AccountSessionManager(IAccountSessionDal accountSessionDal, IMapper mapper, AccountSessionBusinessRules accountSessionBusinessRules)
        {
            _accountSessionDal = accountSessionDal;
            _mapper = mapper;
            _accountSessionBusinessRules = accountSessionBusinessRules;
        }

        public async Task<CreatedAccountSessionResponse> AddAsync(CreateAccountSessionRequest createAccountSessionRequest)
        {
            AccountSession accountSession = _mapper.Map<AccountSession>(createAccountSessionRequest);
            AccountSession addedAccountSession = await _accountSessionDal.AddAsync(accountSession);
            CreatedAccountSessionResponse createdAccountSessionResponse = _mapper.Map<CreatedAccountSessionResponse>(addedAccountSession);
            return createdAccountSessionResponse;

        }

        public async Task<DeletedAccountSessionResponse> DeleteAsync(DeleteAccountSessionRequest deleteAccountSessionRequest)
        {
            await _accountSessionBusinessRules.IsExistsAccountSession(deleteAccountSessionRequest.Id);
            AccountSession accountSession = await _accountSessionDal.GetAsync(predicate: a => a.Id == deleteAccountSessionRequest.Id);
            AccountSession deletedAccountSession = await _accountSessionDal.DeleteAsync(accountSession,false);
            DeletedAccountSessionResponse createdAccountSessionResponse = _mapper.Map<DeletedAccountSessionResponse>(deletedAccountSession);
            return createdAccountSessionResponse;

        }

        public async Task<GetListAccountSessionResponse> GetByIdAsync(Guid id)
        {
            var accountSession = await _accountSessionDal.GetAsync(a => a.Id == id);
            var mappedAccountSession = _mapper.Map<GetListAccountSessionResponse>(accountSession);
            return mappedAccountSession;
        }

        public async Task<IPaginate<GetListAccountSessionResponse>> GetListAsync()
        {
            var accountSession = await _accountSessionDal.GetListAsync();
            var mappedAccountSession = _mapper.Map<Paginate<GetListAccountSessionResponse>>(accountSession);
            return mappedAccountSession;
        }

        public async Task<UpdatedAccountSessionResponse> UpdateAsync(UpdateAccountSessionRequest updateAccountSessionRequest)
        {
            await _accountSessionBusinessRules.IsExistsAccountSession(updateAccountSessionRequest.SessionId);
            AccountSession accountSession = _mapper.Map<AccountSession>(updateAccountSessionRequest);
            AccountSession updatedAccountSession = await _accountSessionDal.UpdateAsync(accountSession);
            UpdatedAccountSessionResponse updatedAccountSessionResponse = _mapper.Map<UpdatedAccountSessionResponse>(updatedAccountSession);
            return updatedAccountSessionResponse;
        }
    }
}
