using AutoMapper;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, CreateSessionRequest>().ReverseMap();
            CreateMap<Session, CreatedSessionResponse>().ReverseMap();

            CreateMap<Session, UpdateSessionRequest>().ReverseMap();
            CreateMap<Session, UpdatedSessionResponse>().ReverseMap();

            CreateMap<Session, DeleteSessionRequest>().ReverseMap();
            CreateMap<Session, DeletedSessionResponse>().ReverseMap();

            CreateMap<IPaginate<Session>, Paginate<GetListSessionResponse>>().ReverseMap();

            CreateMap<Session, GetListSessionResponse>()
               .ForMember(dest => dest.LessonName, opt => opt.MapFrom(src => src.Lesson.Name))
               .ForMember(dest => dest.OccupationClassName, opt => opt.MapFrom(src =>
                   string.Join(", ", src.Lesson.EducationProgramLessons
                       .SelectMany(epl => epl.EducationProgram.EducationProgramOccupationClasses
                           .Select(epoc => epoc.OccupationClass.Name)))))
               .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => string.Join(", ", src.AccountSessions.Select(accountSession => $"{accountSession.Account.User.FirstName} {accountSession.Account.User.LastName}"))))
               .ReverseMap();
        }
    }
}
