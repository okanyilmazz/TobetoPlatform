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
    public class EducationProgramLessonProfile : Profile
    {
        public EducationProgramLessonProfile()
        {
            CreateMap<EducationProgramLesson, CreateEducationProgramLessonRequest>().ReverseMap();
            CreateMap<EducationProgramLesson, CreatedEducationProgramLessonResponse>().ReverseMap();

            CreateMap<EducationProgramLesson, UpdateEducationProgramLessonRequest>().ReverseMap();
            CreateMap<EducationProgramLesson, UpdatedEducationProgramLessonResponse>().ReverseMap();

            CreateMap<EducationProgramLesson, DeleteEducationProgramLessonRequest>().ReverseMap();
            CreateMap<EducationProgramLesson, DeletedEducationProgramLessonResponse>().ReverseMap();

            CreateMap<EducationProgramLesson, GetListEducationProgramLessonResponse>().ReverseMap();
            CreateMap<IPaginate<EducationProgramLesson>, Paginate<GetListEducationProgramLessonResponse>>().ReverseMap();
        }
    }
}
