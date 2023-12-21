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
    public class ExamQuestionTypeProfile : Profile
    {
        public ExamQuestionTypeProfile()
        {
            CreateMap<ExamQuestionType, CreateExamQuestionTypeRequest>().ReverseMap();
            CreateMap<ExamQuestionType, UpdateExamQuestionTypeRequest>().ReverseMap();
            CreateMap<ExamQuestionType, DeleteExamQuestionTypeRequest>().ReverseMap();

            CreateMap<ExamQuestionType, CreatedExamQuestionTypeResponse>().ReverseMap();
            CreateMap<ExamQuestionType, UpdatedExamQuestionTypeResponse>().ReverseMap();
            CreateMap<ExamQuestionType, DeletedExamQuestionTypeResponse>().ReverseMap();

            CreateMap<IPaginate<ExamQuestionType>, Paginate<GetListExamQuestionTypeResponse>>().ReverseMap();
            CreateMap<ExamQuestionType, GetListExamQuestionTypeResponse>().ReverseMap();
        }
    }
}
