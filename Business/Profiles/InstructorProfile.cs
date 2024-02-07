using AutoMapper;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();

            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();

            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

            CreateMap<IPaginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
            CreateMap<Instructor, GetListInstructorResponse>();
             
        }
    }
}
//.ForMember(
//                 destinationMember: response => response.,
//                 memberOptions: opt => opt.MapFrom(c => c..Id)).ReverseMap();