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
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, CreateSessionRequest>().ReverseMap();
            CreateMap<Session, CreatedSessionResponse>().ReverseMap();

            CreateMap<Session, UpdateSessionRequest>().ReverseMap();
            CreateMap<Session, UpdatedSessionResponse>().ReverseMap();

            CreateMap<Session, DeleteSessionRequest>().ReverseMap();
            CreateMap<Session, DeletedSessionResponse>().ReverseMap();

            CreateMap<IPaginate<Session>, Paginate<GetListSessionResponse>>().ReverseMap();

            CreateMap<Session, GetListSessionResponse>()
            .ForMember(destinationMember: response => response.OccupationClassName,
            memberOptions: opt => opt.MapFrom(s => s.OccupationClass.Name)).ReverseMap();
        }
    }
}
