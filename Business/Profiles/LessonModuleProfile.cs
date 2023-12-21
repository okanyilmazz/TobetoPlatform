using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses;
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
    public class LessonModuleProfile : Profile
    {
        public LessonModuleProfile()
        {
            CreateMap<LessonModule, CreateLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, CreatedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, UpdateLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, UpdatedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, DeleteLessonModuleRequest>().ReverseMap();
            CreateMap<LessonModule, DeletedLessonModuleResponse>().ReverseMap();

            CreateMap<LessonModule, GetListLessonModuleResponse>().ReverseMap();
            CreateMap<IPaginate<LessonModule>, Paginate<GetListLessonModuleResponse>>().ReverseMap();
        }
    }
}
