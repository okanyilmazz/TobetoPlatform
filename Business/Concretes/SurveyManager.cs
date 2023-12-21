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

namespace Business.Concretes;

public class SurveyManager : ISurveyService
{
    ISurveyDal _surveyDal;
    IMapper _mapper;
    SurveyBusinessRules _surveyBusinessRules;

    public SurveyManager(ISurveyDal surveyDal, IMapper mapper, SurveyBusinessRules surveyBusinessRules)
    {
        _surveyDal = surveyDal;
        _mapper = mapper;
        _surveyBusinessRules = surveyBusinessRules;
    }

    public async Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest)
    {
        Survey survey = _mapper.Map<Survey>(createSurveyRequest);
        Survey createdSurvey = await _surveyDal.AddAsync(survey);
        CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(createdSurvey);
        return createdSurveyResponse;
    }

    public async Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest)
    {
        await _surveyBusinessRules.IsExistsSurvey(deleteSurveyRequest.Id);
        Survey survey = _mapper.Map<Survey>(deleteSurveyRequest);
        Survey deletedSurvey = await _surveyDal.DeleteAsync(survey, true);
        DeletedSurveyResponse deletedSurveyResponse = _mapper.Map<DeletedSurveyResponse>(deletedSurvey);
        return deletedSurveyResponse;
    }

    public async Task<IPaginate<GetListSurveyResponse>> GetListAsync()
    {
        var surveys = await _surveyDal.GetListAsync();
        var mappedSurveys = _mapper.Map<Paginate<GetListSurveyResponse>>(surveys);
        return mappedSurveys;
    }

    public async Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
    {
        await _surveyBusinessRules.IsExistsSurvey(updateSurveyRequest.Id);
        Survey survey = _mapper.Map<Survey>(updateSurveyRequest);
        Survey updatedSurvey = await _surveyDal.UpdateAsync(survey);
        UpdatedSurveyResponse updatedSurveyResponse = _mapper.Map<UpdatedSurveyResponse>(updatedSurvey);
        return updatedSurveyResponse;
    }
}
