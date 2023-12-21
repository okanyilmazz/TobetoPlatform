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
    public class EducationProgramProgrammingLanguageProfile : Profile

    {
        public EducationProgramProgrammingLanguageProfile()
        {
            CreateMap<EducationProgramProgrammingLanguage, CreateEducationProgramProgrammingLanguageRequest>().ReverseMap();
            CreateMap<EducationProgramProgrammingLanguage, CreatedEducationProgramProgrammingLanguageResponse>().ReverseMap();

            CreateMap<EducationProgramProgrammingLanguage, DeleteEducationProgramProgrammingLanguageRequest>().ReverseMap();
            CreateMap<EducationProgramProgrammingLanguage, DeletedEducationProgramProgrammingLanguageResponse>().ReverseMap();

            CreateMap<EducationProgramProgrammingLanguage, UpdateEducationProgramProgrammingLanguageRequest>().ReverseMap();
            CreateMap<EducationProgramProgrammingLanguage, UpdatedEducationProgramProgrammingLanguageResponse>().ReverseMap();


            CreateMap<IPaginate<EducationProgramProgrammingLanguage>, Paginate<GetListEducationProgramProgrammingLanguageResponse>>().ReverseMap();
            CreateMap<EducationProgramProgrammingLanguage, GetListEducationProgramProgrammingLanguageResponse>().ReverseMap();
        }
    }
}
