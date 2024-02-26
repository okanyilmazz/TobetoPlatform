using AutoMapper;
using Business.Dtos.Requests.ModuleRequests;
using Business.Dtos.Responses.ModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMap<Module, CreateModuleRequest>().ReverseMap();
        CreateMap<Module, CreatedModuleResponse>().ReverseMap();

        CreateMap<Module, UpdateModuleRequest>().ReverseMap();
        CreateMap<Module, UpdatedModuleResponse>().ReverseMap();

        CreateMap<Module, DeleteModuleRequest>().ReverseMap();
        CreateMap<Module, DeletedModuleResponse>().ReverseMap();

        CreateMap<IPaginate<Module>, Paginate<GetListModuleResponse>>().ReverseMap();

        CreateMap<Module, GetListModuleResponse>()
            .ForMember(dest => dest.Children, opt => opt.MapFrom(m => m.Children))
            .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.LessonModules.Select(epm => epm.Lesson)))
     .ReverseMap();
    }
}
