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
    public class AccountOccupationClassProfile : Profile
    {
        public AccountOccupationClassProfile()
        {
            CreateMap<AccountOccupationClass, CreateAccountOccupationClassRequest>().ReverseMap();
            CreateMap<AccountOccupationClass, UpdateAccountOccupationClassRequest>().ReverseMap();
            CreateMap<AccountOccupationClass, DeleteAccountOccupationClassRequest>().ReverseMap();

            CreateMap<AccountOccupationClass, CreatedAccountOccupationClassResponse>().ReverseMap();
            CreateMap<AccountOccupationClass, UpdatedAccountOccupationClassResponse>().ReverseMap();
            CreateMap<AccountOccupationClass, DeletedAccountOccupationClassResponse>().ReverseMap();

            CreateMap<IPaginate<AccountOccupationClass>, Paginate<GetListAccountOccupationClassResponse>>().ReverseMap();
            CreateMap<AccountOccupationClass, GetListAccountOccupationClassResponse>().ReverseMap();
        }
    }
}
