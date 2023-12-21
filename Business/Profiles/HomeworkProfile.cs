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
    public class HomeworkProfile : Profile
    {
        public HomeworkProfile()
        {
            CreateMap<Homework, CreateHomeworkRequest>().ReverseMap();
            CreateMap<Homework, CreatedHomeworkResponse>().ReverseMap();

            CreateMap<Homework, UpdateHomeworkRequest>().ReverseMap();
            CreateMap<Homework, UpdatedHomeworkResponse>().ReverseMap();

            CreateMap<Homework, DeleteHomeworkRequest>().ReverseMap();
            CreateMap<Homework, DeletedHomeworkResponse>().ReverseMap();

            CreateMap<IPaginate<Homework>, Paginate<GetListHomeworkResponse>>().ReverseMap();
            CreateMap<Homework, GetListHomeworkResponse>().ReverseMap();  
        }
    }
}
