﻿using AutoMapper;
using Business.Dtos.Requests.EducationProgramLessonRequests;
using Business.Dtos.Responses.EducationProgramLessonResponses;
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

            CreateMap<EducationProgramLesson, GetListEducationProgramLessonResponse>()
                .ForMember(destinationMember: response => response.EducationProgramName,
                memberOptions: opt => opt.MapFrom(epl => epl.EducationProgram.Name)
                ).ForMember(destinationMember: response => response.LessonName,
                memberOptions: opt => opt.MapFrom(epl => epl.Lesson.Name)
                )
                .ReverseMap();
            CreateMap<IPaginate<EducationProgramLesson>, Paginate<GetListEducationProgramLessonResponse>>().ReverseMap();
        }
    }
}
