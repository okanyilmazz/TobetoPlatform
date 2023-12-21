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

namespace Business.Profiles;

public class SurveyProfile : Profile
{
    public SurveyProfile()
    {
        CreateMap<Survey, CreateSurveyRequest>().ReverseMap();
        CreateMap<Survey, UpdateSurveyRequest>().ReverseMap();
        CreateMap<Survey, DeleteSurveyRequest>().ReverseMap();

        CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

        CreateMap<Survey, GetListSurveyResponse>().ReverseMap();
        CreateMap<IPaginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();
    }
}
