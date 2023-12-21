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
    public class EducationProgramOccupationClassProfile : Profile
    {
        public EducationProgramOccupationClassProfile()
        {
            CreateMap<EducationProgramOccupationClass, CreateEducationProgramOccupationClassRequest>().ReverseMap();
            CreateMap<EducationProgramOccupationClass, CreatedEducationProgramOccupationClassResponse>().ReverseMap();

            CreateMap<EducationProgramOccupationClass, DeleteEducationProgramOccupationClassRequest>().ReverseMap();
            CreateMap<EducationProgramOccupationClass, DeletedEducationProgramOccupationClassResponse>().ReverseMap();

            CreateMap<EducationProgramOccupationClass, UpdateEducationProgramOccupationClassRequest>().ReverseMap();
            CreateMap<EducationProgramOccupationClass, UpdatedEducationProgramOccupationClassResponse>().ReverseMap();

            CreateMap<IPaginate<EducationProgramOccupationClass>, Paginate<GetListEducationProgramOccupationClassResponse>>().ReverseMap();
            CreateMap<EducationProgramOccupationClass, GetListEducationProgramOccupationClassResponse>().ReverseMap();
        }
    }
}
