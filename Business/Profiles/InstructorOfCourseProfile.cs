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
    public class LessonOfAccountProfile : Profile
    {
        public LessonOfAccountProfile()

        {
            CreateMap<AccountLesson, CreateAccountLessonRequest>().ReverseMap();
            CreateMap<AccountLesson, CreatedAccountLessonResponse>().ReverseMap();

            CreateMap<AccountLesson, UpdateAccountLessonRequest>().ReverseMap();
            CreateMap<AccountLesson, UpdatedAccountLessonResponse>().ReverseMap();

            CreateMap<AccountLesson, DeleteAccountLessonRequest>().ReverseMap();
            CreateMap<AccountLesson, DeletedAccountLessonResponse>().ReverseMap();

            CreateMap<IPaginate<AccountLesson>, Paginate<GetListAccountLessonResponse>>().ReverseMap();
            CreateMap<AccountLesson, GetListAccountLessonResponse>().ReverseMap();
        }
    }
}
