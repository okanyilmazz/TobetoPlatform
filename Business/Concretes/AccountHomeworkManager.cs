﻿using AutoMapper;
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
    public class AccountHomeworkManager : IAccountHomeworkService
    {
        IAccountHomeworkDal _accountHomeworkDal;
        IMapper _mapper;
        AccountHomeworkBusinessRules _accountHomeworkBusinessRules;
        public AccountHomeworkManager(IAccountHomeworkDal accountHomeworkDal, IMapper mapper, AccountHomeworkBusinessRules accountHomeworkBusinessRules)
        {
            _accountHomeworkDal = accountHomeworkDal;
            _mapper = mapper;
            _accountHomeworkBusinessRules = accountHomeworkBusinessRules;
        }


        public async Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest)
        {
            AccountHomework accountHomework = _mapper.Map<AccountHomework>(createAccountHomeworkRequest);
            AccountHomework createdAccountHomework = await _accountHomeworkDal.AddAsync(accountHomework);
            CreatedAccountHomeworkResponse createdAccountHomeworkResponse = _mapper.Map<CreatedAccountHomeworkResponse>(createdAccountHomework);
            return createdAccountHomeworkResponse;
        }

        public async Task<DeletedAccountHomeworkResponse> DeleteAsync(DeleteAccountHomeworkRequest deleteAccountHomeworkRequest)
        {
            await _accountHomeworkBusinessRules.IsExistsAccountHomework(deleteAccountHomeworkRequest.Id);
            AccountHomework accountHomework = await _accountHomeworkDal.GetAsync(predicate: a => a.Id == deleteAccountHomeworkRequest.Id);
            AccountHomework deletedAccountHomework = await _accountHomeworkDal.DeleteAsync(accountHomework);
            DeletedAccountHomeworkResponse deletedAccountHomeworkeResponse = _mapper.Map<DeletedAccountHomeworkResponse>(deletedAccountHomework);
            return deletedAccountHomeworkeResponse;
        }

        public async Task<GetListAccountHomeworkResponse> GetByIdAsync(Guid id)
        {
            var accountHomework = await _accountHomeworkDal.GetAsync(
                predicate: a => a.Id == id,
                include: ah => ah
                .Include(ah => ah.Account).ThenInclude(a => a.User)
                .Include(ah => ah.Homework));
            var mappedAccountHomework = _mapper.Map<GetListAccountHomeworkResponse>(accountHomework);
            return mappedAccountHomework;
        }

        public async Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync()
        {
            var accountHomework = await _accountHomeworkDal.GetListAsync(
                include: ah => ah
                .Include(ah => ah.Account).ThenInclude(a => a.User)
                .Include(ah => ah.Homework));
            var mappedAccountHomework = _mapper.Map<Paginate<GetListAccountHomeworkResponse>>(accountHomework);
            return mappedAccountHomework;
        }

        public async Task<UpdatedAccountHomeworkeResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest)
        {
            await _accountHomeworkBusinessRules.IsExistsAccountHomework(updateAccountHomeworkRequest.Id);
            AccountHomework accountHomework = _mapper.Map<AccountHomework>(updateAccountHomeworkRequest);
            AccountHomework updatedAccountHomework = await _accountHomeworkDal.UpdateAsync(accountHomework);
            UpdatedAccountHomeworkeResponse updatedAccountHomeworkeResponse = _mapper.Map<UpdatedAccountHomeworkeResponse>(updatedAccountHomework);
            return updatedAccountHomeworkeResponse;
        }
    }
}
