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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExamOccupationClassProfile : Profile
    {
        public ExamOccupationClassProfile()
        {
            CreateMap<ExamOccupationClass, CreateExamOccupationClassRequest>().ReverseMap();
            CreateMap<ExamOccupationClass, CreatedExamOccupationClassResponse>().ReverseMap();

            CreateMap<ExamOccupationClass, UpdateExamOccupationClassRequest>().ReverseMap();
            CreateMap<ExamOccupationClass, UpdatedExamOccupationClassResponse>().ReverseMap();

            CreateMap<ExamOccupationClass, DeleteExamOccupationClassRequest>().ReverseMap();
            CreateMap<ExamOccupationClass, DeletedExamOccupationClassResponse>().ReverseMap();

            CreateMap<ExamOccupationClass, GetListExamOccupationClassResponse>()
                .ForMember(destinationMember: response => response.ExamName,
                memberOptions: opt => opt.MapFrom(eoc => eoc.Exam.Name))
                .ForMember(destinationMember: response => response.OccupationClassName,
                memberOptions: opt => opt.MapFrom(eoc => eoc.OccupationClass.Name))
                .ReverseMap();
            CreateMap<IPaginate<ExamOccupationClass>, Paginate<GetListExamOccupationClassResponse>>().ReverseMap();
        }
    }
}
