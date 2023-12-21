using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OccupationClassSurveyManager : IOccupationClassSurveyService
    {

        IOccupationClassSurveyDal _occupationClassSurveyDal;
        IMapper _mapper;
        OccupationClassSurveyBusinessRules _occupationClassSurveyBusinessRules;

        public OccupationClassSurveyManager(IOccupationClassSurveyDal occupationClassSurveyDal, IMapper mapper, OccupationClassSurveyBusinessRules occupationClassSurveyBusinessRules)
        {
            _occupationClassSurveyDal = occupationClassSurveyDal;
            _mapper = mapper;
            _occupationClassSurveyBusinessRules = occupationClassSurveyBusinessRules;
        }

        public async Task<CreatedOccupationClassSurveyResponse> AddAsync(CreateOccupationClassSurveyRequest createOccupationClassSurveyRequest)
        {
            OccupationClassSurvey OccupationClassSurvey = _mapper.Map<OccupationClassSurvey>(createOccupationClassSurveyRequest);
            OccupationClassSurvey createdOccupationClassSurvey = await _occupationClassSurveyDal.AddAsync(OccupationClassSurvey);
            CreatedOccupationClassSurveyResponse createdOccupationClassSurveyResponse = _mapper.Map<CreatedOccupationClassSurveyResponse>(createdOccupationClassSurvey);
            return createdOccupationClassSurveyResponse;
        }

        public async Task<DeletedOccupationClassSurveyResponse> DeleteAsync(DeleteOccupationClassSurveyRequest deleteOccupationClassSurveyRequest)
        {
            await _occupationClassSurveyBusinessRules.IsExistsOccupationClassSurvey(deleteOccupationClassSurveyRequest.Id);
            OccupationClassSurvey OccupationClassSurvey = _mapper.Map<OccupationClassSurvey>(deleteOccupationClassSurveyRequest);
            OccupationClassSurvey deletedOccupationClassSurvey = await _occupationClassSurveyDal.DeleteAsync(OccupationClassSurvey);
            DeletedOccupationClassSurveyResponse deletedOccupationClassSurveyResponse = _mapper.Map<DeletedOccupationClassSurveyResponse>(deletedOccupationClassSurvey);
            return deletedOccupationClassSurveyResponse;
        }

        public async Task<IPaginate<GetListOccupationClassSurveyResponse>> GetListAsync()
        {
            var OccupationClassSurveys = await _occupationClassSurveyDal.GetListAsync();
            var mappedOccupationClassSurveys = _mapper.Map<Paginate<GetListOccupationClassSurveyResponse>>(OccupationClassSurveys);
            return mappedOccupationClassSurveys;
        }

        public async Task<UpdatedOccupationClassSurveyResponse> UpdateAsync(UpdateOccupationClassSurveyRequest updateOccupationClassSurveyRequest)
        {
            await _occupationClassSurveyBusinessRules.IsExistsOccupationClassSurvey(updateOccupationClassSurveyRequest.Id);
            OccupationClassSurvey OccupationClassSurvey = _mapper.Map<OccupationClassSurvey>(updateOccupationClassSurveyRequest);
            OccupationClassSurvey updatedOccupationClassSurvey = await _occupationClassSurveyDal.UpdateAsync(OccupationClassSurvey);
            UpdatedOccupationClassSurveyResponse updatedOccupationClassSurveyResponse = _mapper.Map<UpdatedOccupationClassSurveyResponse>(updatedOccupationClassSurvey);
            return updatedOccupationClassSurveyResponse;
        }
    }
}
