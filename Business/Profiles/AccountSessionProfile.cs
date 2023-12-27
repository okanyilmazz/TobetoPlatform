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
    public class AccountSessionProfile : Profile
    {
        public AccountSessionProfile()
        {
            CreateMap<AccountSession, CreatedAccountSessionResponse>().ReverseMap();
            CreateMap<AccountSession, CreateAccountSessionRequest>().ReverseMap();

            CreateMap<AccountSession, UpdateAccountSessionRequest>().ReverseMap();
            CreateMap<AccountSession, UpdatedAccountSessionResponse>().ReverseMap();

            CreateMap<AccountSession, DeleteAccountSessionRequest>().ReverseMap();
            CreateMap<AccountSession, DeletedAccountSessionResponse>().ReverseMap();

            CreateMap<AccountSession, GetListAccountSessionResponse>()
                .ForMember(destinationMember: ase => ase.AccountName,
                memberOptions: opt => opt.MapFrom(ase => ase.Account.User.FirstName))
                .ReverseMap();
            CreateMap<IPaginate<AccountSession>, Paginate<GetListAccountSessionResponse>>().ReverseMap();
        }
    }
}
