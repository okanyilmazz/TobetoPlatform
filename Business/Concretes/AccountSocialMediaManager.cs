using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
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
    public class AccountSocialMediaManager : IAccountSocialMediaService
    {
        IAccountSocialMediaDal _accountSocialMediaDal;
        IMapper _mapper;

        public AccountSocialMediaManager(IAccountSocialMediaDal accountSocialMediaDal, IMapper mapper)
        {
            _accountSocialMediaDal = accountSocialMediaDal;
            _mapper = mapper;
        }
        public async Task<CreatedAccountSocialMediaResponse> AddAsync(CreateAccountSocialMediaRequest createAccountSocialMediaRequest)
        {
            AccountSocialMedia accountSocialMedia = _mapper.Map<AccountSocialMedia>(createAccountSocialMediaRequest);
            AccountSocialMedia addedAccountSocialMedia = await _accountSocialMediaDal.AddAsync(accountSocialMedia);
            CreatedAccountSocialMediaResponse createdAccountSocialMediaResponse = _mapper.Map<CreatedAccountSocialMediaResponse>(addedAccountSocialMedia);
            return createdAccountSocialMediaResponse;
        }

        public async Task<DeletedAccountSocialMediaResponse> DeleteAsync(DeleteAccountSocialMediaRequest deleteAccountSocialMediaRequest)
        {
            AccountSocialMedia accountSocialMedia = _mapper.Map<AccountSocialMedia>(deleteAccountSocialMediaRequest);
            AccountSocialMedia deletedAccountSocialMedia = await _accountSocialMediaDal.DeleteAsync(accountSocialMedia);
            DeletedAccountSocialMediaResponse deletedAccountSocialMediaResponse = _mapper.Map<DeletedAccountSocialMediaResponse>(deletedAccountSocialMedia);
            return deletedAccountSocialMediaResponse;
        }

        public async Task<IPaginate<GetListAccountSocialMediaResponse>> GetListAsync()
        {
            var accountSocialMediaList = await _accountSocialMediaDal.GetListAsync();
            var mappedAccountSocialMedias = _mapper.Map<Paginate<GetListAccountSocialMediaResponse>>(accountSocialMediaList);
            return mappedAccountSocialMedias;
        }

        public async Task<UpdatedAccountSocialMediaResponse> UpdateAsync(UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest)
        {
            AccountSocialMedia social = _mapper.Map<AccountSocialMedia>(updateAccountSocialMediaRequest);
            AccountSocialMedia updatedAccountSocialMedia = await _accountSocialMediaDal.UpdateAsync(social);
            UpdatedAccountSocialMediaResponse updatedAccountSocialMediaResponse = _mapper.Map<UpdatedAccountSocialMediaResponse>(updatedAccountSocialMedia);
            return updatedAccountSocialMediaResponse;
        }
    }
}
