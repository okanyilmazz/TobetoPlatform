using System;
using AutoMapper;
using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Requests.AccountBadgeRequests;
using Business.Dtos.Responses.AccountActivityMapResponses;
using Business.Dtos.Responses.AccountBadgeResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class AccountActivityMapProfile : Profile
{
    public AccountActivityMapProfile()
    {

        CreateMap<AccountActivityMap, CreateAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, CreatedAccountActivityMapResponse>().ReverseMap();

        CreateMap<AccountActivityMap, UpdateAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, UpdatedAccountActivityMapResponse>().ReverseMap();

        CreateMap<AccountActivityMap, DeleteAccountActivityMapRequest>().ReverseMap();
        CreateMap<AccountActivityMap, DeletedAccountActivityMapResponse>().ReverseMap();
        CreateMap<IPaginate<AccountActivityMap>, Paginate<GetListAccountActivityMapResponse>>().ReverseMap();

        CreateMap<AccountActivityMap, GetListAccountActivityMapResponse>()
            .ForMember(destinationMember: response => response.AccountName,
            memberOptions: opt => opt.MapFrom(ab => ab.Account.User.FirstName + " " + ab.Account.User.LastName))
            
            .ReverseMap();

        CreateMap<List<AccountActivityMap>, Paginate<GetListAccountActivityMapResponse>>()
            .ForMember(destinationMember: ab => ab.Items,
            memberOptions: opt => opt.MapFrom(h => h.ToList())).ReverseMap();

    }
}

