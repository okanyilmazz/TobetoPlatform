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

            CreateMap<Account, GetListAccountResponse>()
                .ForMember(destinationMember: response => response.DistrictName,
                memberOptions: a => a.MapFrom(a => a.Address.District.Name))
                .ForMember(destinationMember: response => response.CityName,
                memberOptions: a => a.MapFrom(a => a.Address.City.Name))
                .ForMember(destinationMember: response => response.CountryName,
                memberOptions: a => a.MapFrom(a => a.Address.Country.Name))
                .ForMember(destinationMember: response => response.UserName,
                memberOptions: a => a.MapFrom(a => a.User.FirstName))
                .ReverseMap();
            CreateMap<IPaginate<Account>, Paginate<GetListAccountResponse>>().ReverseMap();

            CreateMap<List<Account>, Paginate<GetListAccountResponse>>().ForMember(destinationMember: h => h.Items,
                memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();
        }
    }
}
