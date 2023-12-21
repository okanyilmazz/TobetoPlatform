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
    public class MediaNewProfile : Profile
    {
        public MediaNewProfile()
        {
            CreateMap<MediaNew, CreateMediaNewRequest>().ReverseMap();
            CreateMap<MediaNew, CreatedMediaNewResponse>().ReverseMap();

            CreateMap<MediaNew, UpdateMediaNewRequest>().ReverseMap();
            CreateMap<MediaNew, UpdatedMediaNewResponse>().ReverseMap();

            CreateMap<MediaNew, DeleteMediaNewRequest>().ReverseMap();
            CreateMap<MediaNew, DeletedMediaNewResponse>().ReverseMap();

            CreateMap<MediaNew, GetListMediaNewResponse>().ReverseMap();
            CreateMap<IPaginate<MediaNew>, Paginate<GetListMediaNewResponse>>().ReverseMap();
        }
    }
}
