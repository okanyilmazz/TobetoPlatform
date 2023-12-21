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
    public class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            CreateMap<ExamResultProfile, CreateExamResultRequest>().ReverseMap();
            CreateMap<ExamResultProfile, CreatedExamResultResponse>().ReverseMap();

            CreateMap<ExamResultProfile, UpdateExamResultRequest>().ReverseMap();
            CreateMap<ExamResultProfile, UpdatedExamResultResponse>().ReverseMap();

            CreateMap<ExamResultProfile, DeleteExamResultRequest>().ReverseMap();
            CreateMap<ExamResultProfile, DeletedExamResultResponse>().ReverseMap();

            CreateMap<IPaginate<ExamResultProfile>, Paginate<GetListExamResultResponse>>().ReverseMap();
            CreateMap<ExamResultProfile, GetListExamResultResponse>().ReverseMap();
        }
    }
}
