using AutoMapper;
using Business.Dtos.Requests.EducationProgramModuleRequests;
using Business.Dtos.Responses.EducationProgramModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class EducationProgramModuleProfile : Profile
{
    public EducationProgramModuleProfile()
    {
        CreateMap<EducationProgramModule, CreateEducationProgramModuleRequest>().ReverseMap();
        CreateMap<EducationProgramModule, UpdateEducationProgramModuleRequest>().ReverseMap();
        CreateMap<EducationProgramModule, DeleteEducationProgramModuleRequest>().ReverseMap();

        CreateMap<EducationProgramModule, CreatedEducationProgramModuleResponse>().ReverseMap();
        CreateMap<EducationProgramModule, UpdatedEducationProgramModuleResponse>().ReverseMap();
        CreateMap<EducationProgramModule, DeletedEducationProgramModuleResponse>().ReverseMap();

        CreateMap<IPaginate<EducationProgramModule>, Paginate<GetListEducationProgramModuleResponse>>().ReverseMap();
        CreateMap<EducationProgramModule, GetListEducationProgramModuleResponse>().ReverseMap();
    }
}
