using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ModuleRequests;
using Business.Dtos.Responses.ModuleResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ModuleManager : IModuleService
{
    IModuleDal _moduleDal;
    IMapper _mapper;
    ModuleBusinessRules _moduleBusinessRules;

    public ModuleManager(IModuleDal moduleDal, IMapper mapper, ModuleBusinessRules moduleBusinessRules)
    {
        _moduleDal = moduleDal;
        _mapper = mapper;
        _moduleBusinessRules = moduleBusinessRules;
    }

    public async Task<CreatedModuleResponse> AddAsync(CreateModuleRequest createModuleRequest)
    {
        Module module = _mapper.Map<Module>(createModuleRequest);
        Module addedModule = await _moduleDal.AddAsync(module);
        CreatedModuleResponse createdModuleResponse = _mapper.Map<CreatedModuleResponse>(addedModule);
        return createdModuleResponse;
    }

    public async Task<DeletedModuleResponse> DeleteAsync(DeleteModuleRequest deleteModuleRequest)
    {
        await _moduleBusinessRules.IsExistsModule(deleteModuleRequest.Id);
        Module module = await _moduleDal.GetAsync(predicate: a => a.Id == deleteModuleRequest.Id);
        Module deletedModule = await _moduleDal.DeleteAsync(module);
        DeletedModuleResponse deletedModuleResponse = _mapper.Map<DeletedModuleResponse>(deletedModule);
        return deletedModuleResponse;
    }

    public async Task<GetListModuleResponse> GetByIdAsync(Guid id)
    {
        var module = await _moduleDal.GetAsync(m => m.Id == id);
        var mappedModule = _mapper.Map<GetListModuleResponse>(module);
        return mappedModule;
    }

    public async Task<IPaginate<GetListModuleResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var modules = await _moduleDal.GetListAsync(
            predicate:m => m.EducationProgramModules.Any(epm => epm.EducationProgramId == educationProgramId));
        var mappedModule = _mapper.Map<Paginate<GetListModuleResponse>>(modules);
        return mappedModule;
    }


    public async Task<IPaginate<GetListModuleResponse>> GetListAsync(PageRequest pageRequest)
    {
        var modules = await _moduleDal.GetListAsync(
            include: m => m
            .Include(m => m.Parent.Children)
            .Include(m => m.LessonModules).ThenInclude(lm => lm.Lesson).ThenInclude(l => l.Language)
            .Include(m => m.LessonModules).ThenInclude(lm => lm.Lesson).ThenInclude(l => l.ProductionCompany)
            .Include(m => m.LessonModules).ThenInclude(lm => lm.Lesson).ThenInclude(l => l.LessonSubType)
            .Include(m => m.LessonModules).ThenInclude(lm => lm.Lesson).ThenInclude(l => l.LessonCategory),
            size: pageRequest.PageSize,
            index: pageRequest.PageIndex);

        var mappedModules = _mapper.Map<Paginate<GetListModuleResponse>>(modules);
        return mappedModules;
    }



    public async Task<UpdatedModuleResponse> UpdateAsync(UpdateModuleRequest updateModuleRequest)
    {
        await _moduleBusinessRules.IsExistsModule(updateModuleRequest.Id);
        Module module = _mapper.Map<Module>(updateModuleRequest);
        Module updatedModule = await _moduleDal.UpdateAsync(module);
        UpdatedModuleResponse updatedModuleResponse = _mapper.Map<UpdatedModuleResponse>(updatedModule);
        return updatedModuleResponse;
    }

}
