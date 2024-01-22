using AutoMapper;
using Business.Dtos.Requests.LessonRequests;
using Business.Dtos.Responses.LessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, CreateLessonRequest>().ReverseMap();
            CreateMap<Lesson, DeleteLessonRequest>().ReverseMap();
            CreateMap<Lesson, UpdateLessonRequest>().ReverseMap();
            CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();
            CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();
            CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();
            CreateMap<IPaginate<Lesson>, Paginate<GetListLessonResponse>>().ReverseMap();
            CreateMap<Lesson, GetListLessonResponse>().ReverseMap();

            CreateMap<List<Lesson>, Paginate<GetListLessonResponse>>().ForMember
            (destinationMember: a => a.Items, memberOptions: l => l.MapFrom(l => l.ToList())).ReverseMap();
        }
    }
}
