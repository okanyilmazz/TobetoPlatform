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
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CreateCityRequest>().ReverseMap();
            CreateMap<City, CreatedCityResponse>().ReverseMap();

            CreateMap<City, DeleteCityRequest>().ReverseMap();
            CreateMap<City, DeletedCityResponse>().ReverseMap();

            CreateMap<City, UpdateCityRequest>().ReverseMap();
            CreateMap<City, UpdatedCityResponse>().ReverseMap();

            CreateMap<IPaginate<City>, Paginate<GetListCityResponse>>().ReverseMap();
            CreateMap<City, GetListCityResponse>().ReverseMap();
        }
    }
}
