using AutoMapper;
using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses.LessonModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LessonModuleProfile : Profile
{
    public LessonModuleProfile()
    {
        CreateMap<LessonModule, CreateLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, CreatedLessonModuleResponse>().ReverseMap();

        CreateMap<LessonModule, UpdateLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, UpdatedLessonModuleResponse>().ReverseMap();

        CreateMap<LessonModule, DeleteLessonModuleRequest>().ReverseMap();
        CreateMap<LessonModule, DeletedLessonModuleResponse>().ReverseMap();

        CreateMap<IPaginate<LessonModule>, Paginate<GetListLessonModuleResponse>>().ReverseMap();
        CreateMap<LessonModule, GetListLessonModuleResponse>()
.ForMember(destinationMember:dest=>dest.Lessons,
memberOptions:opt=>opt.MapFrom(l=>l.Lesson))            
            .ReverseMap();
    }
}
