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
    public class OccupationClassSurveyProfile :  Profile
    {
        public OccupationClassSurveyProfile()
        {
            CreateMap<OccupationClassSurvey, CreateOccupationClassSurveyRequest>().ReverseMap();
            CreateMap<OccupationClassSurvey, CreatedOccupationClassSurveyResponse>().ReverseMap();

            CreateMap<OccupationClassSurvey, DeleteOccupationClassSurveyRequest>().ReverseMap();
            CreateMap<OccupationClassSurvey, DeletedOccupationClassSurveyResponse>().ReverseMap();

            CreateMap<OccupationClassSurvey, UpdateOccupationClassSurveyRequest>().ReverseMap();
            CreateMap<OccupationClassSurvey, UpdatedOccupationClassSurveyResponse>().ReverseMap();

            CreateMap<IPaginate<OccupationClassSurvey>, Paginate<GetListOccupationClassSurveyResponse>>().ReverseMap();
            CreateMap<OccupationClassSurvey, GetListOccupationClassSurveyResponse>().ReverseMap();
        }
    }
}
