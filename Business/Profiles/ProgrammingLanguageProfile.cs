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
    public class ProgrammingLanguageProfile : Profile
    {
        public ProgrammingLanguageProfile()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageRequest>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageResponse>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageRequest>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageResponse>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageRequest>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageResponse>().ReverseMap();

            CreateMap<ProgrammingLanguage, GetListProgrammingLanguageResponse>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, Paginate<GetListProgrammingLanguageResponse>>().ReverseMap();
        }
    }
}
