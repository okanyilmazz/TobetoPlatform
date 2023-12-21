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
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, CreateQuestionRequest>().ReverseMap();
            CreateMap<Question, CreatedQuestionResponse>().ReverseMap();

            CreateMap<Question, UpdateQuestionRequest>().ReverseMap();
            CreateMap<Question, UpdatedQuestionResponse>().ReverseMap();

            CreateMap<Question, DeleteQuestionRequest>().ReverseMap();
            CreateMap<Question, DeletedQuestionResponse>().ReverseMap();

            CreateMap<Question, GetListQuestionResponse>().ReverseMap();
            CreateMap<IPaginate<Question>, Paginate<GetListQuestionResponse>>().ReverseMap();
        }
    }
}
