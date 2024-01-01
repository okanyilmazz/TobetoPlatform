using AutoMapper;
using Azure;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AccountSkillProfile : Profile
    {
        public AccountSkillProfile()
        {
            CreateMap<AccountSkill, CreateAccountSkillRequest>().ReverseMap();
            CreateMap<AccountSkill, CreatedAccountSkillResponse>().ReverseMap();

            CreateMap<AccountSkill, UpdateAccountSkillRequest>().ReverseMap();
            CreateMap<AccountSkill, UpdatedAccountSkillResponse>().ReverseMap();

            CreateMap<AccountSkill, DeleteAccountSkillRequest>().ReverseMap();
            CreateMap<AccountSkill, DeletedAccountSkillResponse>().ReverseMap();

            CreateMap<AccountSkill, GetListAccountSkillResponse>()
                .ForMember(destinationMember:response=>response.SkillName,memberOptions:
                opt=>opt.MapFrom(acs=>acs.Skill.Name))
                .ForMember(destinationMember:response=>response.AccountName,memberOptions:
                opt=>opt.MapFrom(acs=>acs.Account.User.FirstName+" "+ acs.Account.User.LastName))
                .ReverseMap();
            CreateMap<IPaginate<AccountSkill>, Paginate<GetListAccountSkillResponse>>().ReverseMap();

        }
    }
}
