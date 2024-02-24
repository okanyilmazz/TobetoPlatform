﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponses;
using Business.Dtos.Responses.UniversityResponses;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Business.Rules;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Entities;
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
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;
        IMapper _mapper;
        OperationClaimBusinessRules _operationClaimBusinessRules;

        public OperationClaimManager(IOperationClaimDal operationClaimDal, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
            OperationClaim addedOperationClaim = await _operationClaimDal.AddAsync(operationClaim);
            CreatedOperationClaimResponse createdOperationClaimResponse = _mapper.Map<CreatedOperationClaimResponse>(addedOperationClaim);
            return createdOperationClaimResponse;
        }

    public async Task<List<GetListOperationClaimResponse>> GetByUserIdAsync(Guid userId)
    {
        var operationClaims = await _operationClaimDal.GetListAsync(
            include: oc => oc.Include(oc => oc.UserOperationClaims),
            predicate: oc => oc.UserOperationClaims.Any(uoc => uoc.UserId == userId));

        var operationClaimResponse = _mapper.Map<List<GetListOperationClaimResponse>>(operationClaims.Items);
        return operationClaimResponse;
    }
        public async Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest)
        {
            await _operationClaimBusinessRules.IsExistsOperationClaim(deleteOperationClaimRequest.Id);
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(predicate: op => op.Id == deleteOperationClaimRequest.Id);
            OperationClaim deletedOperationClaim = await _operationClaimDal.DeleteAsync(operationClaim);
            DeletedOperationClaimResponse deletedOperationClaimResponse = _mapper.Map<DeletedOperationClaimResponse>(deletedOperationClaim);
            return deletedOperationClaimResponse;
        }

        public async Task<IPaginate<GetListOperationClaimResponse>> GetListAsync(PageRequest pageRequest)
        {
            var operationClaim = await _operationClaimDal.GetListAsync(
                                       index: pageRequest.PageIndex,
                                       size: pageRequest.PageSize
                                       );
            var mappedOperationClaim = _mapper.Map<Paginate<GetListOperationClaimResponse>>(operationClaim);
            return mappedOperationClaim;
        }

        public async Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(updateOperationClaimRequest);
            OperationClaim updatedOperationClaim = await _operationClaimDal.UpdateAsync(operationClaim);
            UpdatedOperationClaimResponse updatedOperationClaimResponse = _mapper.Map<UpdatedOperationClaimResponse>(updatedOperationClaim);
            return updatedOperationClaimResponse;
        }
    }
} 
