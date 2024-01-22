using AutoMapper;
using Business.Dtos.Requests.EducationProgramRequests;
using Business.Dtos.Responses.EducationProgramResponses;
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
              
            CreateMap<EducationProgram, GetListEducationProgramResponse>()
                   .ForMember(destinationMember: response => response.EducationProgramLevelName,
                memberOptions: opt => opt.MapFrom(e => e.EducationProgramLevel.Name))
                .ReverseMap();
            


            CreateMap<List<EducationProgram>, Paginate<GetListEducationProgramResponse>>()
                .ForMember(destinationMember: p => p.Items,
                memberOptions: opt => opt.MapFrom(p => p.ToList())).ReverseMap();

             


        }
    }
}
