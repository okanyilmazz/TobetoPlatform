using System;
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

namespace Business.Profiles
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            CreateMap<QuestionType, CreateQuestionTypeRequest>().ReverseMap();
            CreateMap<QuestionType, CreatedQuestionTypeResponse>().ReverseMap();

            CreateMap<QuestionType, UpdateQuestionTypeRequest>().ReverseMap();
            CreateMap<QuestionType, UpdatedQuestionTypeResponse>().ReverseMap();

            CreateMap<QuestionType, DeleteQuestionTypeRequest>().ReverseMap();
            CreateMap<QuestionType, DeletedQuestionTypeResponse>().ReverseMap();

            CreateMap<QuestionType, GetListQuestionTypeResponse>().ReverseMap();
            CreateMap<IPaginate<QuestionType>, Paginate<GetListQuestionTypeResponse>>().ReverseMap();

        }
    }
}

