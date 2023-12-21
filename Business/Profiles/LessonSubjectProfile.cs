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
    public class LessonSubjectProfile : Profile
    {
        public LessonSubjectProfile()
        {
            CreateMap<LessonSubject, CreateLessonSubjectRequest>().ReverseMap();
            CreateMap<LessonSubject, UpdateLessonSubjectRequest>().ReverseMap();
            CreateMap<LessonSubject, DeleteLessonSubjectRequest>().ReverseMap();

            CreateMap<LessonSubject, CreatedLessonSubjectResponse>().ReverseMap();
            CreateMap<LessonSubject, UpdatedLessonSubjectResponse>().ReverseMap();
            CreateMap<LessonSubject, DeletedLessonSubjectResponse>().ReverseMap();

            CreateMap<IPaginate<LessonSubject>, Paginate<GetListLessonSubjectResponse>>().ReverseMap();
            CreateMap<LessonSubject, GetListLessonSubjectResponse>().ReverseMap();
        }
    }
}