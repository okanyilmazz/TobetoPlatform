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
    public class AccountLessonManager : IAccountLessonService
    {
        IAccountLessonDal _accountLessonDal;
        IMapper _mapper;
        AccountLessonBusinessRules _accountLessonBusinessRules;
        public AccountLessonManager(IAccountLessonDal accountLessonDal, IMapper mapper, AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _accountLessonDal = accountLessonDal;
            _mapper = mapper;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }


        public async Task<CreatedAccountLessonResponse> AddAsync(CreateAccountLessonRequest createAccountLessonRequest)
        {
            var AccountLesson = _mapper.Map<AccountLesson>(createAccountLessonRequest);
            var addedAccountLesson = await _accountLessonDal.AddAsync(AccountLesson);
            var responseAccountLesson = _mapper.Map<CreatedAccountLessonResponse>(addedAccountLesson);
            return responseAccountLesson;
        }

        public async Task<DeletedAccountLessonResponse> DeleteAsync(DeleteAccountLessonRequest deleteAccountLessonRequest)
        {
            await _accountLessonBusinessRules.IsExistsAccountLesson(deleteAccountLessonRequest.Id);
            var AccountLesson = _mapper.Map<AccountLesson>(deleteAccountLessonRequest);
            var deletedAccountLesson = await _accountLessonDal.DeleteAsync(AccountLesson);
            var responseAccountLesson = _mapper.Map<DeletedAccountLessonResponse>(deletedAccountLesson);
            return responseAccountLesson;
        }

        public async Task<GetListAccountLessonResponse> GetByIdAsync(Guid id)
        {
            var AccountLessonListed = await _accountLessonDal.GetAsync(a => a.Id == id);
            var mappedListed = _mapper.Map<GetListAccountLessonResponse>(AccountLessonListed);
            return mappedListed;
        }

        public async Task<IPaginate<GetListAccountLessonResponse>> GetListAsync()
        {
            var AccountLessonListed = await _accountLessonDal.GetListAsync();
            var mappedListed = _mapper.Map<Paginate<GetListAccountLessonResponse>>(AccountLessonListed);
            return mappedListed;
        }

        public async Task<UpdatedAccountLessonResponse> UpdateAsync(UpdateAccountLessonRequest updateAccountLessonRequest)
        {
            await _accountLessonBusinessRules.IsExistsAccountLesson(updateAccountLessonRequest.Id);
            var AccountLesson = _mapper.Map<AccountLesson>(updateAccountLessonRequest);
            var updatedAccountLesson = await _accountLessonDal.UpdateAsync(AccountLesson);
            var responseAccountLesson = _mapper.Map<UpdatedAccountLessonResponse>(updatedAccountLesson);
            return responseAccountLesson;
        }
    }
}