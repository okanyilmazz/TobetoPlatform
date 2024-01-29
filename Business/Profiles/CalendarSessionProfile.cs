using AutoMapper;
using Business.Dtos.Requests.CalendarSessionRequests;
using Business.Dtos.Responses.CalendarSessionResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CalendarSessionProfile : Profile
    {
        public CalendarSessionProfile()
        {
            CreateMap<CalendarSession, CreateCalendarSessionRequest>().ReverseMap();
            CreateMap<CalendarSession, CreatedCalendarSessionResponse>().ReverseMap();

            CreateMap<CalendarSession, UpdateCalendarSessionRequest>().ReverseMap();
            CreateMap<CalendarSession, UpdatedCalendarSessionResponse>().ReverseMap();

            CreateMap<CalendarSession, DeleteCalendarSessionRequest>().ReverseMap();
            CreateMap<CalendarSession, DeletedCalendarSessionResponse>().ReverseMap();

            CreateMap<IPaginate<CalendarSession>, Paginate<GetListCalendarSessionResponse>>().ReverseMap();
            CreateMap<CalendarSession, GetListCalendarSessionResponse>()
            .ForMember(
                 destinationMember: response => response.SessionId,
                 memberOptions: opt => opt.MapFrom(c => c.Session.Id))
            .ForMember(
                 destinationMember: response => response.UserOperationClaimId,
                 memberOptions: opt => opt.MapFrom(c => c.UserOperationClaim.UserId))
            .ForMember(
                 destinationMember: response => response.OccupationClassName,
                 memberOptions: opt => opt.MapFrom(c => c.Session.OccupationClass.Name))
            .ForMember(
                 destinationMember: response => response.StartDate,
                 memberOptions: opt => opt.MapFrom(c => c.Session.StartDate))
            .ForMember(
                 destinationMember: response => response.EndDate,
                 memberOptions: opt => opt.MapFrom(c => c.Session.EndDate))
            .ForMember(
                 destinationMember: response => response.UserFirstName,
                 memberOptions: opt => opt.MapFrom(c => c.UserOperationClaim.User.FirstName))
            .ForMember(
                 destinationMember: response => response.UserLastName,
                 memberOptions: opt => opt.MapFrom(c => c.UserOperationClaim.User.LastName))
            .ReverseMap();
        }
    }
}
