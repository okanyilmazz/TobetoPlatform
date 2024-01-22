using AutoMapper;
using Business.Dtos.Requests.AccountLessonRequests;
using Business.Dtos.Responses.AccountLessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AccountLessonProfile : Profile
    {
        public AccountLessonProfile()
        {
            CreateMap<AccountLesson, CreateAccountLessonRequest>().ReverseMap();
            CreateMap<AccountLesson, UpdateAccountLessonRequest>().ReverseMap();
            CreateMap<AccountLesson, DeleteAccountLessonRequest>().ReverseMap();

            CreateMap<AccountLesson, CreatedAccountLessonResponse>().ReverseMap();
            CreateMap<AccountLesson, UpdatedAccountLessonResponse>().ReverseMap();
            CreateMap<AccountLesson, DeletedAccountLessonResponse>().ReverseMap();

            CreateMap<IPaginate<AccountLesson>, Paginate<GetListAccountLessonResponse>>().ReverseMap();
            CreateMap<AccountLesson, GetListAccountLessonResponse>()
                .ForMember(destinationMember: response => response.LessonName,
                memberOptions: opt => opt.MapFrom(al => al.Lesson.Name))
                .ForMember(destinationMember: response => response.AccountName,
                memberOptions: opt => opt.MapFrom(al => al.Account.User.FirstName))
                .ReverseMap();
        }
    }
}
