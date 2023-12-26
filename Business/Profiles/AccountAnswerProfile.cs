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
    public class AccountAnswerProfile : Profile
    {
        public AccountAnswerProfile() 
        {
            CreateMap<AccountAnswer, CreateAccountAnswerRequest>().ReverseMap();
            CreateMap<AccountAnswer, CreatedAccountAnswerResponse>().ReverseMap();

            CreateMap<AccountAnswer, UpdateAccountAnswerRequest>().ReverseMap();
            CreateMap<AccountAnswer, UpdatedAccountAnswerResponse>().ReverseMap();

            CreateMap<AccountAnswer, DeleteAccountAnswerRequest>().ReverseMap();
            CreateMap<AccountAnswer, DeletedAccountAnswerResponse>().ReverseMap();

            CreateMap<AccountAnswer, GetListAccountAnswerResponse>()
                 .ForMember(destinationMember: caar => caar.ExamName,
                memberOptions: opt => opt.MapFrom(aa => aa.Exam.Name))

                 .ForMember(destinationMember:caar=>caar.AccountName,
                 memberOptions:opt=>opt.MapFrom(aa=>aa.Account.User.FirstName))

                 .ForMember(destinationMember:caar=>caar.QuestionName,
                 memberOptions:opt=>opt.MapFrom(aa=>aa.Question.Description)).ReverseMap();

            CreateMap<IPaginate<AccountAnswer>, Paginate<GetListAccountAnswerResponse>>().ReverseMap();
        }
    }
}
