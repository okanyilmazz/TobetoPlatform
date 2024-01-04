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

public class WorkExperienceProfile : Profile
{
    public WorkExperienceProfile()
    {
        CreateMap<WorkExperience, CreateWorkExperienceRequest>().ReverseMap();
        CreateMap<WorkExperience, UpdateWorkExperienceRequest>().ReverseMap();
        CreateMap<WorkExperience, DeleteWorkExperienceRequest>().ReverseMap();

        CreateMap<WorkExperience, CreatedWorkExperienceResponse>().ReverseMap();
        CreateMap<WorkExperience, UpdatedWorkExperienceResponse>().ReverseMap();
        CreateMap<WorkExperience, DeletedWorkExperienceResponse>().ReverseMap();

        CreateMap<WorkExperience, GetListWorkExperienceResponse>().ReverseMap();
        CreateMap<IPaginate<WorkExperience>, Paginate<GetListWorkExperienceResponse>>().ReverseMap();

        CreateMap<WorkExperience, GetListWorkExperienceResponse>()
               .ForMember(destinationMember: response => response.CityName,
               memberOptions: opt => opt.MapFrom(we => we.City.Name))
               .ForMember(destinationMember: response => response.AccountName,
               memberOptions: opt => opt.MapFrom(we => we.Account.User.FirstName)).ReverseMap();



    }
}
