﻿using AutoMapper;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Profiles;

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

        CreateMap<User, LoginAuthRequest>().ReverseMap();
        CreateMap<User, RegisterAuthRequest>().ReverseMap();
        CreateMap<User, GetUserResponse>().ReverseMap();

        CreateMap<User,GetListUserResponse>().ReverseMap();
        CreateMap<IPaginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
    }
}
