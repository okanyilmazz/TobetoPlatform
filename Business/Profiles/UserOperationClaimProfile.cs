using AutoMapper;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Responses.AccountAnswerResponses;
using Business.Dtos.Responses.AccountResponses;
using Business.Dtos.Responses.SocialMediaResponses;
using Business.Dtos.Responses.UserOperationClaimResponses;
using Core.DataAccess.Paging;
using Core.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserOperationClaimProfile : Profile
    {
        public UserOperationClaimProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>()
                .ForMember(destinationMember: uoc => uoc.FirstName,
                memberOptions: uoc => uoc.MapFrom(uoc => uoc.User.FirstName))
                .ForMember(destinationMember: uoc => uoc.LastName,
                memberOptions: uoc => uoc.MapFrom(uoc => uoc.User.LastName))
                .ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, Paginate<GetListUserOperationClaimResponse>>();
        }
    }
}
