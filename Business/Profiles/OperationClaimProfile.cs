﻿using AutoMapper;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponses;
using Core.DataAccess.Paging;
using Core.Entities;

namespace Business.Profiles;

public class OperationClaimProfile : Profile
{
    public OperationClaimProfile()
    {

        CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, DeleteOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();

        CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

        CreateMap<IPaginate<OperationClaim>, Paginate<GetListOperationClaimResponse>>().ReverseMap();
        CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();

        CreateMap<List<OperationClaim>, Paginate<OperationClaim>>()
            .ForMember(destinationMember: oc => oc.Items,
          memberOptions: opt => opt.MapFrom(glopc => glopc.ToList())).ReverseMap();
    }
}
