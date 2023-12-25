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
    public class AccountAnswerManager : IAccountAnswerService
    {
        IAccountAnswerDal _accountAnswerDal;
        IMapper _mapper;
        AccountAnswerBusinessRules _accountAnswerBusinessRules;

        public AccountAnswerManager(IAccountAnswerDal accountAnswerDal, IMapper mapper, AccountAnswerBusinessRules accountAnswerBusinessRules)
        {
            _accountAnswerDal = accountAnswerDal;
            _mapper = mapper;
            _accountAnswerBusinessRules = accountAnswerBusinessRules;
        }
        public async Task<CreatedAccountAnswerResponse> AddAsync(CreateAccountAnswerRequest createAccountAnswerRequest)
        {
            AccountAnswer accountAnswer = _mapper.Map<AccountAnswer>(createAccountAnswerRequest);
            AccountAnswer addedAccountAnswer = await _accountAnswerDal.AddAsync(accountAnswer);
            CreatedAccountAnswerResponse createdAccountAnswerResponse = _mapper.Map<CreatedAccountAnswerResponse>(addedAccountAnswer);
            return createdAccountAnswerResponse;
        }

        public async Task<DeletedAccountAnswerResponse> DeleteAsync(DeleteAccountAnswerRequest deleteAccountAnswerRequest)
        {
            await _accountAnswerBusinessRules.IsExistsAccountAnswer(deleteAccountAnswerRequest.Id);
            AccountAnswer accountAnswer = await _accountAnswerDal.GetAsync(predicate: l => l.Id == deleteAccountAnswerRequest.Id);
            AccountAnswer deletedAccountAnswer = await _accountAnswerDal.DeleteAsync(accountAnswer);
            DeletedAccountAnswerResponse deletedAccountAnswerResponse = _mapper.Map<DeletedAccountAnswerResponse>(deletedAccountAnswer);
            return deletedAccountAnswerResponse;
        }

        public async Task<GetListAccountAnswerResponse> GetByIdAsync(Guid id)
        {
            var accountAnswers = await _accountAnswerDal.GetAsync(a => a.Id == id);
            var mappedAccountAnswers = _mapper.Map<GetListAccountAnswerResponse>(accountAnswers);
            return mappedAccountAnswers;
        }

        public async Task<IPaginate<GetListAccountAnswerResponse>> GetListAsync()
        {
            var accountAnswers = await _accountAnswerDal.GetListAsync();
            var mappedAccountAnswers = _mapper.Map<Paginate<GetListAccountAnswerResponse>>(accountAnswers);
            return mappedAccountAnswers;
        }

        public async Task<UpdatedAccountAnswerResponse> UpdateAsync(UpdateAccountAnswerRequest updateAccountAnswerRequest)
        {
            await _accountAnswerBusinessRules.IsExistsAccountAnswer(updateAccountAnswerRequest.Id);
            AccountAnswer accountAnswer = _mapper.Map<AccountAnswer>(updateAccountAnswerRequest);
            AccountAnswer updatedAccountAnswer = await _accountAnswerDal.UpdateAsync(accountAnswer);
            UpdatedAccountAnswerResponse updatedAccountAnswerResponse = _mapper.Map<UpdatedAccountAnswerResponse>(updatedAccountAnswer);
            return updatedAccountAnswerResponse;
        }
    }
}
