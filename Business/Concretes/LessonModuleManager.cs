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

public class LessonModuleManager : ILessonModuleService
{
    ILessonModuleDal _lessonModuleDal;
    IMapper _mapper;
    LessonModuleBusinessRules _lessonModuleBusinessRules;


    public LessonModuleManager(ILessonModuleDal lessonModuleDal, IMapper mapper, LessonModuleBusinessRules lessonModuleBusinessRules)
    {
        _lessonModuleDal = lessonModuleDal;
        _mapper = mapper;
        _lessonModuleBusinessRules = lessonModuleBusinessRules;
    }

    public async Task<CreatedLessonModuleResponse> AddAsync(CreateLessonModuleRequest createLessonModuleRequest)
    {
        LessonModule lessonModule = _mapper.Map<LessonModule>(createLessonModuleRequest);
        LessonModule addedLessonModule = await _lessonModuleDal.AddAsync(lessonModule);
        CreatedLessonModuleResponse createdLessonModuleResponse = _mapper.Map<CreatedLessonModuleResponse>(addedLessonModule);
        return createdLessonModuleResponse;
    }

    public async Task<DeletedLessonModuleResponse> DeleteAsync(DeleteLessonModuleRequest deleteLessonModuleRequest)
    {
        await _lessonModuleBusinessRules.IsExistsLessonModule(deleteLessonModuleRequest.Id);
        LessonModule lessonModule = _mapper.Map<LessonModule>(deleteLessonModuleRequest);
        LessonModule deletedLessonModule = await _lessonModuleDal.DeleteAsync(lessonModule);
        DeletedLessonModuleResponse deletedLessonModuleResponse = _mapper.Map<DeletedLessonModuleResponse>(deletedLessonModule);
        return deletedLessonModuleResponse;
    }

    public async Task<UpdatedLessonModuleResponse> UpdateAsync(UpdateLessonModuleRequest updateLessonModuleRequest)
    {
        await _lessonModuleBusinessRules.IsExistsLessonModule(updateLessonModuleRequest.Id);
        LessonModule lessonModule = _mapper.Map<LessonModule>(updateLessonModuleRequest);
        LessonModule updatedLessonModule = await _lessonModuleDal.UpdateAsync(lessonModule);
        UpdatedLessonModuleResponse updatedLessonModuleResponse = _mapper.Map<UpdatedLessonModuleResponse>(updatedLessonModule);
        return updatedLessonModuleResponse;
    }

    public async Task<IPaginate<GetListLessonModuleResponse>> GetListAsync()
    {
        var lessonModuleListed = await _lessonModuleDal.GetListAsync();
        var mappedListed = _mapper.Map<Paginate<GetListLessonModuleResponse>>(lessonModuleListed);
        return mappedListed;
    }
}
