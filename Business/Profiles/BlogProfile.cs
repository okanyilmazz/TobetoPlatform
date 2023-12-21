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
    public class BlogProfile: Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, CreateBlogRequest>().ReverseMap();
            CreateMap<Blog, CreatedBlogResponse>().ReverseMap();

            CreateMap<Blog, UpdateBlogRequest>().ReverseMap();
            CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();

            CreateMap<Blog, DeleteBlogRequest>().ReverseMap();
            CreateMap<Blog, DeletedBlogResponse>().ReverseMap();


            CreateMap<IPaginate<Blog>, Paginate<GetListBlogResponse>>().ReverseMap();
            CreateMap<Blog, GetListBlogResponse>().ReverseMap();
        }
    }
}
