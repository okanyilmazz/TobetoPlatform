using AutoMapper;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountSocialMediaProfile : Profile
{
    public AccountSocialMediaProfile()
    {
        CreateMap<AccountSocialMedia, CreateAccountSocialMediaRequest>().ReverseMap();
        CreateMap<AccountSocialMedia, UpdateAccountSocialMediaRequest>().ReverseMap();
        CreateMap<AccountSocialMedia, DeleteAccountSocialMediaRequest>().ReverseMap();

        CreateMap<AccountSocialMedia, CreatedAccountSocialMediaResponse>().ReverseMap();
        CreateMap<AccountSocialMedia, UpdatedAccountSocialMediaResponse>().ReverseMap();
        CreateMap<AccountSocialMedia, DeletedAccountSocialMediaResponse>().ReverseMap();

        CreateMap<AccountSocialMedia, GetListAccountSocialMediaResponse>().ReverseMap();
        CreateMap<IPaginate<AccountSocialMedia>, Paginate<GetListAccountSocialMediaResponse>>().ReverseMap();
    }
}
