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
    public class ExamQuestionProfile : Profile
    {
        public ExamQuestionProfile()
        {
            CreateMap<ExamQuestion, CreateExamQuestionRequest>().ReverseMap();
            CreateMap<ExamQuestion, CreatedExamQuestionResponse>().ReverseMap();

            CreateMap<ExamQuestion, UpdateExamQuestionRequest>().ReverseMap();
            CreateMap<ExamQuestion, UpdatedExamQuestionResponse>().ReverseMap();

            CreateMap<ExamQuestion, DeleteExamQuestionRequest>().ReverseMap();
            CreateMap<ExamQuestion, DeletedExamQuestionResponse>().ReverseMap();

            CreateMap<ExamQuestion, GetListExamQuestionResponse>().ReverseMap();
            CreateMap<IPaginate<ExamQuestion>, Paginate<GetListExamQuestionResponse>>().ReverseMap();

        }
    }
}

