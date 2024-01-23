﻿using Business.Dtos.Requests.AccountAnswerRequests;
using Business.Dtos.Requests.AccountEducationProgramRequests;
using Business.Dtos.Responses.AccountAnswerResponses;
using Business.Dtos.Responses.AccountEducationProgramResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountEducationProgramService
{
    Task<CreatedAccountEducationProgramResponse> AddAsync(CreateAccountEducationProgramRequest createAccountEducationProgramRequest);
    Task<UpdatedAccountEducationProgramResponse> UpdateAsync(UpdateAccountEducationProgramRequest updateAccountEducationProgramRequest);
    Task<DeletedAccountEducationProgramResponse> DeleteAsync(DeleteAccountEducationProgramRequest deleteAccountEducationProgramRequest);
    Task<IPaginate<GetListAccountEducationProgramResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountEducationProgramResponse> GetByIdAsync(Guid id);
}