using System;
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

namespace Business.Profiles
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, CreatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, UpdateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, DeleteSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<IPaginate<SocialMedia>, Paginate<GetListSocialMediaResponse>>().ReverseMap();
        }
    }
}

