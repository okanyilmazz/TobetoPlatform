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
    public class ProductionCompanyProfile : Profile
	{
        public ProductionCompanyProfile()
        {
            CreateMap<ProductionCompany, CreateProductionCompanyRequest>().ReverseMap();
            CreateMap<ProductionCompany, CreatedProductionCompanyResponse>().ReverseMap();

            CreateMap<ProductionCompany, UpdateProductionCompanyRequest>().ReverseMap();
            CreateMap<ProductionCompany, UpdatedProductionCompanyResponse>().ReverseMap();

            CreateMap<ProductionCompany, DeleteProductionCompanyRequest>().ReverseMap();
            CreateMap<ProductionCompany, DeletedProductionCompanyResponse>().ReverseMap();

            CreateMap<ProductionCompany, GetListProductionCompanyResponse>().ReverseMap();
            CreateMap<IPaginate<ProductionCompany>, Paginate<GetListProductionCompanyResponse>>().ReverseMap();

        }
    }
}

