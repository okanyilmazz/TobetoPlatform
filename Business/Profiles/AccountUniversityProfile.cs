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
    public class AccountUniversityProfile : Profile
    {
        public AccountUniversityProfile()
        {
            CreateMap<AccountUniversity, CreateAccountUniversityRequest>().ReverseMap();
            CreateMap<AccountUniversity, CreatedAccountUniversityResponse>().ReverseMap();

            CreateMap<AccountUniversity, UpdateAccountUniversityRequest>().ReverseMap();
            CreateMap<AccountUniversity, UpdatedAccountUniversityResponse>().ReverseMap();

            CreateMap<AccountUniversity, DeleteAccountUniversityRequest>().ReverseMap();
            CreateMap<AccountUniversity, DeletedAccountUniversityResponse>().ReverseMap();

            CreateMap<AccountUniversity, GetListAccountUniversityResponse>()
                .ForMember(destinationMember: response => response.UniversityName,
                memberOptions: opt => opt.MapFrom(au => au.University.Name))
                .ForMember(destinationMember: response => response.UniversityDepartmentName,
                memberOptions: opt => opt.MapFrom(au => au.UniversityDepartment.Name))
                .ForMember(destinationMember: response => response.DegreeTypeName,
                memberOptions: opt => opt.MapFrom(au => au.DegreeType.Name))
                .ForMember(destinationMember: response => response.AccountName,
                memberOptions: opt => opt.MapFrom(au => au.Account.User.FirstName))
                .ReverseMap();
            CreateMap<IPaginate<AccountUniversity>, Paginate<GetListAccountUniversityResponse>>().ReverseMap();
        }
    }
}
