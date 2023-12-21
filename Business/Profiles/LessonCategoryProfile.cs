using AutoMapper;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.GetListResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LessonCategoryProfile : Profile
    {
        public LessonCategoryProfile()
        {
            CreateMap<LessonCategory, CreateLessonCategoryRequest>().ReverseMap();

            CreateMap<LessonCategory, CreatedLessonCategoryResponse>().ReverseMap();
            CreateMap<IPaginate<LessonCategory>, Paginate<GetListLessonCategoryResponse>>().ReverseMap();

            CreateMap<LessonCategory, GetListLessonCategoryResponse>().ReverseMap();
        }
    }
}
