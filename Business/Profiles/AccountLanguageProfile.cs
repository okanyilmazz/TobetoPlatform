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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AccountLanguageProfile : Profile
    {
        public AccountLanguageProfile()
        {
            CreateMap<AccountLanguage, CreateAccountLanguageRequest>().ReverseMap();
            CreateMap<AccountLanguage, CreatedAccountLanguageResponse>().ReverseMap();

            CreateMap<AccountLanguage, UpdateAccountLanguageRequest>().ReverseMap();
            CreateMap<AccountLanguage, UpdatedAccountLanguageResponse>().ReverseMap();

            CreateMap<AccountLanguage, DeleteAccountLanguageRequest>().ReverseMap();
            CreateMap<AccountLanguage, DeletedAccountLanguageResponse>().ReverseMap();

            CreateMap<AccountLanguage, GetListAccountLanguageResponse>().ReverseMap();
            CreateMap<IPaginate<AccountLanguage>, Paginate<GetListAccountLanguageResponse>>().ReverseMap();
        }

    }
}
