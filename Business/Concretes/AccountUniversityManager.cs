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

namespace Business.Concretes;

public class AccountUniversityManager : IAccountUniversityService
{

    IAccountUniversityDal _accountUniversityDal;
    IMapper _mapper;
    AccountUniversityBusinessRules _accountUniversityBusinessRules;

    public AccountUniversityManager(IAccountUniversityDal accountUniversityDal, IMapper mapper, AccountUniversityBusinessRules accountUniversityBusinessRules)
    {
        _accountUniversityDal = accountUniversityDal;
        _mapper = mapper;
        _accountUniversityBusinessRules = accountUniversityBusinessRules;
    }

    public async Task<CreatedAccountUniversityResponse> AddAsync(CreateAccountUniversityRequest createAccountUniversityRequest)
    {
        AccountUniversity accountUniversity = _mapper.Map<AccountUniversity>(createAccountUniversityRequest);
        AccountUniversity createdAccountUniversity = await _accountUniversityDal.AddAsync(accountUniversity);
        CreatedAccountUniversityResponse createdAccountUniversityResponse = _mapper.Map<CreatedAccountUniversityResponse>(createdAccountUniversity);
        return createdAccountUniversityResponse;
    }

    public async Task<DeletedAccountUniversityResponse> DeleteAsync(DeleteAccountUniversityRequest deleteAccountUniversityRequest)
    {
        await _accountUniversityBusinessRules.IsExistsAccountUniversity(deleteAccountUniversityRequest.Id);
        AccountUniversity accountUniversity = await _accountUniversityDal.GetAsync(predicate: au => au.Id == deleteAccountUniversityRequest.Id);
        AccountUniversity deletedAccountUniversity = await _accountUniversityDal.DeleteAsync(accountUniversity);
        DeletedAccountUniversityResponse deletedAccountUniversityResponse = _mapper.Map<DeletedAccountUniversityResponse>(deletedAccountUniversity);
        return deletedAccountUniversityResponse;


    }

    public async Task<GetListAccountUniversityResponse> GetByIdAsync(Guid Id)
    {
        var accountUniversities = await _accountUniversityDal.GetAsync(a => a.Id == Id);
        var mappedAccountUniversitie = _mapper.Map<GetListAccountUniversityResponse>(accountUniversities);
        return mappedAccountUniversitie;

    }

    public async Task<IPaginate<GetListAccountUniversityResponse>> GetListAsync()
    {
        var accountUniversities = await _accountUniversityDal.GetListAsync();
        var mappedaccountUniversities = _mapper.Map<Paginate<GetListAccountUniversityResponse>>(accountUniversities);
        return mappedaccountUniversities;
    }

    public async Task<UpdatedAccountUniversityResponse> UpdateAsync(UpdateAccountUniversityRequest updateAccountUniversityRequest)
    {
        await _accountUniversityBusinessRules.IsExistsAccountUniversity(updateAccountUniversityRequest.Id);
        AccountUniversity accountUniversity = _mapper.Map<AccountUniversity>(updateAccountUniversityRequest);
        AccountUniversity updatedAccountUniversity = await _accountUniversityDal.UpdateAsync(accountUniversity);
        UpdatedAccountUniversityResponse updatedAccountUniversityResponse = _mapper.Map<UpdatedAccountUniversityResponse>(updatedAccountUniversity);
        return updatedAccountUniversityResponse;
    }
}
