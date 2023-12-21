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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();

            CreateMap<User, DeleteUserRequest>().ReverseMap();
            CreateMap<User, DeletedUserResponse>().ReverseMap();

            CreateMap<User,GetListUserResponse>().ReverseMap();
            CreateMap<IPaginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
        }
    }
}
