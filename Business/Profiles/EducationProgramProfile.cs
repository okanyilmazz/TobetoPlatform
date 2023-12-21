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
    public class EducationProgramProfile : Profile
    {
        public EducationProgramProfile()
        {
            CreateMap<EducationProgram, CreateEducationProgramRequest>().ReverseMap();
            CreateMap<EducationProgram, UpdateEducationProgramRequest>().ReverseMap();
            CreateMap<EducationProgram, DeleteEducationProgramRequest>().ReverseMap();

            CreateMap<EducationProgram, CreatedEducationProgramResponse>().ReverseMap();
            CreateMap<EducationProgram, UpdatedEducationProgramResponse>().ReverseMap();
            CreateMap<EducationProgram, DeletedEducationProgramResponse>().ReverseMap();

            CreateMap<IPaginate<EducationProgram>, Paginate<GetListEducationProgramResponse>>().ReverseMap();
            CreateMap<EducationProgram, GetListEducationProgramResponse>().ReverseMap();
        }
    }
}
