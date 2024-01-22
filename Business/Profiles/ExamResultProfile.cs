using AutoMapper;
using Business.Dtos.Requests.ExamResultRequests;
using Business.Dtos.Responses.ExamResultResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            CreateMap<ExamResult, CreateExamResultRequest>().ReverseMap();
            CreateMap<ExamResult, CreatedExamResultResponse>().ReverseMap();

            CreateMap<ExamResult, UpdateExamResultRequest>().ReverseMap();
            CreateMap<ExamResult, UpdatedExamResultResponse>().ReverseMap();

            CreateMap<ExamResult, DeleteExamResultRequest>().ReverseMap();
            CreateMap<ExamResult, DeletedExamResultResponse>().ReverseMap();

            CreateMap<IPaginate<ExamResult>, Paginate<GetListExamResultResponse>>().ReverseMap();
            CreateMap<ExamResult, GetListExamResultResponse>().ReverseMap();
        }
    }
}
