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
    public class UniversityProfile : Profile
    {
        public UniversityProfile()
        {
            CreateMap<University, CreateUniversityRequest>().ReverseMap();
            CreateMap<University, CreatedUniversityResponse>().ReverseMap();

            CreateMap<University, UpdateUniversityRequest>().ReverseMap();
            CreateMap<University, UpdatedUniversityResponse>().ReverseMap();

            CreateMap<University, DeleteUniversityRequest>().ReverseMap();
            CreateMap<University, DeletedUniversityResponse>().ReverseMap();

            CreateMap<University, GetListUniversityResponse>().ReverseMap();
            CreateMap<IPaginate<University>, Paginate<GetListUniversityResponse>>().ReverseMap();
        }
    }
}
