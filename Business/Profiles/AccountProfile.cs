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
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, CreatedAccountResponse>().ReverseMap();
            CreateMap<Account, CreateAccountRequest>().ReverseMap();

            CreateMap<Account, UpdateAccountRequest>().ReverseMap();
            CreateMap<Account, UpdatedAccountResponse>().ReverseMap();

            CreateMap<Account, DeleteAccountRequest>().ReverseMap();
            CreateMap<Account, DeletedAccountResponse>().ReverseMap();

            CreateMap<Account, GetListAccountResponse>().ReverseMap();
            CreateMap<IPaginate<Account>, Paginate<GetListAccountResponse>>().ReverseMap();
        }
    }
}
