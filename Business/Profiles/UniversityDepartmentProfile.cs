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
    public class UniversityDepartmentProfile : Profile
    {
        public UniversityDepartmentProfile()
        {
            CreateMap<UniversityDepartment, CreateUniversityDepartmentRequest>().ReverseMap();
            CreateMap<UniversityDepartment, UpdateUniversityDepartmentRequest>().ReverseMap();
            CreateMap<UniversityDepartment, DeleteUniversityDepartmentRequest>().ReverseMap();

            CreateMap<UniversityDepartment, CreatedUniversityDepartmentResponse>().ReverseMap();
            CreateMap<UniversityDepartment, UpdatedUniversityDepartmentResponse>().ReverseMap();
            CreateMap<UniversityDepartment, DeletedUniversityDepartmentResponse>().ReverseMap();

            CreateMap<IPaginate<UniversityDepartment>, Paginate<GetListUniversityDepartmentResponse>>().ReverseMap();
            CreateMap<UniversityDepartment, GetListUniversityDepartmentResponse>().ReverseMap();
        }
    }
}
