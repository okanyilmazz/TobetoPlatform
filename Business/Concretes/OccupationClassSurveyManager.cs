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
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
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
            OccupationClassSurvey occupationClassSurvey = await _occupationClassSurveyDal.GetAsync(predicate: a => a.Id == deleteOccupationClassSurveyRequest.Id);
            OccupationClassSurvey deletedOccupationClassSurvey = await _occupationClassSurveyDal.DeleteAsync(occupationClassSurvey, false);
            DeletedOccupationClassSurveyResponse deletedOccupationClassSurveyResponse = _mapper.Map<DeletedOccupationClassSurveyResponse>(deletedOccupationClassSurvey);
            return deletedOccupationClassSurveyResponse;
        }

        public async Task<GetListOccupationClassSurveyResponse> GetByIdAsync(Guid id)
        {
            var occupationClassSurveyId = await _occupationClassSurveyDal.GetAsync(
                predicate: o => o.Id == id,
                include: ocs => ocs.
                Include(ocs => ocs.OccupationClass)
                .Include(ocs => ocs.Survey));
            var mappedoccupationClassSurvey = _mapper.Map<GetListOccupationClassSurveyResponse>(occupationClassSurveyId);
            return mappedoccupationClassSurvey;
        }

        public async Task<IPaginate<GetListOccupationClassSurveyResponse>> GetListAsync()
        {
            var OccupationClassSurvey = await _occupationClassSurveyDal.GetListAsync(
                 include: ocs => ocs.
                Include(ocs => ocs.OccupationClass)
                .Include(ocs => ocs.Survey));
            var mappedOccupationClassSurvey = _mapper.Map<Paginate<GetListOccupationClassSurveyResponse>>(OccupationClassSurvey);
            return mappedOccupationClassSurvey;
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
