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
    public class AccountHomeworkProfile : Profile
    {
        public AccountHomeworkProfile()
        {
            CreateMap<AccountHomework, CreateAccountHomeworkRequest>().ReverseMap();
            CreateMap<AccountHomework, CreatedAccountHomeworkResponse>().ReverseMap();

            CreateMap<AccountHomework, UpdateAccountHomeworkRequest>().ReverseMap();
            CreateMap<AccountHomework, UpdatedAccountHomeworkeResponse>().ReverseMap();

            CreateMap<AccountHomework, DeleteAccountHomeworkRequest>().ReverseMap();
            CreateMap<AccountHomework, DeletedAccountHomeworkResponse>().ReverseMap();

            CreateMap<IPaginate<AccountHomework>, Paginate<GetListAccountHomeworkResponse>>().ReverseMap();
            CreateMap<AccountHomework, GetListAccountHomeworkResponse>()
                .ForMember(destinationMember: response => response.HomeworkName,
                memberOptions: opt => opt.MapFrom(ah => ah.Homework.Name))
                .ForMember(destinationMember: response => response.AccountName,
                memberOptions: opt => opt.MapFrom(ah => ah.Account.User.FirstName))
                .ReverseMap();

        }
    }
}
