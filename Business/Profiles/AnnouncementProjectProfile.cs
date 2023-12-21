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
    public class AnnouncementProjectProfile : Profile
    {
        public AnnouncementProjectProfile()
        {
            CreateMap<AnnouncementProject, CreateAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, CreatedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, UpdateAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, UpdatedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, DeleteAnnouncementProjectRequest>().ReverseMap();
            CreateMap<AnnouncementProject, DeletedAnnouncementProjectResponse>().ReverseMap();

            CreateMap<AnnouncementProject, GetListAnnouncementProjectResponse>().ReverseMap();
            CreateMap<IPaginate<AnnouncementProject>, Paginate<GetListAnnouncementProjectResponse>>().ReverseMap();
        }
    }
}
