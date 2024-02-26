using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramModuleRequests;
using Business.Dtos.Responses.EducationProgramModuleResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramModuleManager : IEducationProgramModuleService
{
    IEducationProgramModuleDal _educationProgramModuleDal;
    IMapper _mapper;
    EducationProgramModuleBusinessRules _educationProgramModuleBusinessRules;

    public EducationProgramModuleManager(IEducationProgramModuleDal educationProgramModuleDal, IMapper mapper, EducationProgramModuleBusinessRules educationProgramModuleBusinessRules)
    {
        _educationProgramModuleDal = educationProgramModuleDal;
        _mapper = mapper;
        _educationProgramModuleBusinessRules = educationProgramModuleBusinessRules;
    }

    public async Task<CreatedEducationProgramModuleResponse> AddAsync(CreateEducationProgramModuleRequest createEducationProgramModuleRequest)
    {
        EducationProgramModule educationProgramModule = _mapper.Map<EducationProgramModule>(createEducationProgramModuleRequest);
        EducationProgramModule createdEducationProgramModule = await _educationProgramModuleDal.AddAsync(educationProgramModule);
        CreatedEducationProgramModuleResponse createdEducationProgramModuleResponse = _mapper.Map<CreatedEducationProgramModuleResponse>(createdEducationProgramModule);
        return createdEducationProgramModuleResponse;
    }

    public async Task<DeletedEducationProgramModuleResponse> DeleteAsync(DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest)
    {
        await _educationProgramModuleBusinessRules.IsExistsEducationProgramModule(deleteEducationProgramModuleRequest.Id);
        EducationProgramModule educationProgramModule = await _educationProgramModuleDal.GetAsync(
            predicate: l => l.Id == deleteEducationProgramModuleRequest.Id);
        EducationProgramModule deletedEducationProgramModule = await _educationProgramModuleDal.DeleteAsync(educationProgramModule);
        DeletedEducationProgramModuleResponse deletedEducationProgramModuleResponse = _mapper.Map<DeletedEducationProgramModuleResponse>(deletedEducationProgramModule);
        return deletedEducationProgramModuleResponse;
    }

    public async Task<DeletedEducationProgramModuleResponse> DeleteByModuleIdAndEducationProgramIdAsync(DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest)
    {
        await _educationProgramModuleBusinessRules.IsExistsEducationProgramModuleByModuleIdAndEducationProgramId(deleteEducationProgramModuleRequest.ModuleId, deleteEducationProgramModuleRequest.EducationProgramId);
        EducationProgramModule educationProgramModule = await _educationProgramModuleDal.GetAsync(
        predicate: epl => epl.ModuleId == deleteEducationProgramModuleRequest.ModuleId && epl.EducationProgramId == deleteEducationProgramModuleRequest.EducationProgramId);
        EducationProgramModule deletedEducationProgramModule = await _educationProgramModuleDal.DeleteAsync(educationProgramModule, permanent: true);
        DeletedEducationProgramModuleResponse deletedEducationProgramModuleResponse = _mapper.Map<DeletedEducationProgramModuleResponse>(deletedEducationProgramModule);
        return deletedEducationProgramModuleResponse;
    }

    public async Task<GetListEducationProgramModuleResponse> GetByIdAsync(Guid id)
    {
        var educationProgramModule = await _educationProgramModuleDal.GetAsync(
            predicate: l => l.Id == id,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Module));

        var mappedEducationProgramModules = _mapper.Map<GetListEducationProgramModuleResponse>(educationProgramModule);
        return mappedEducationProgramModules;
    }

    public async Task<IPaginate<GetListEducationProgramModuleResponse>> GetByModuleIdAsync(Guid moduleId)
    {
        var educationProgramModule = await _educationProgramModuleDal.GetListAsync(
            predicate: l => l.ModuleId == moduleId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Module));

        var mappedEducationProgramModules = _mapper.Map<Paginate<GetListEducationProgramModuleResponse>>(educationProgramModule);
        return mappedEducationProgramModules;
    }

    public async Task<IPaginate<GetListEducationProgramModuleResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var educationProgramModule = await _educationProgramModuleDal.GetListAsync(
            predicate: l => l.EducationProgramId == educationProgramId,
            include: l => l.
            Include(l => l.EducationProgram).
            Include(l => l.Module));

        var mappedEducationProgramModules = _mapper.Map<Paginate<GetListEducationProgramModuleResponse>>(educationProgramModule);
        return mappedEducationProgramModules;
    }

    public async Task<IPaginate<GetListEducationProgramModuleResponse>> GetListAsync(PageRequest pageRequest)
    {
        var educationProgramModule = await _educationProgramModuleDal.GetListAsync(
             include: l => l.
             Include(l => l.EducationProgram).
             Include(l => l.Module),
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);

        var mappedEducationProgramModules = _mapper.Map<Paginate<GetListEducationProgramModuleResponse>>(educationProgramModule);
        return mappedEducationProgramModules;
    }

    public async Task<UpdatedEducationProgramModuleResponse> UpdateAsync(UpdateEducationProgramModuleRequest updateEducationProgramModuleRequest)
    {
        await _educationProgramModuleBusinessRules.IsExistsEducationProgramModule(updateEducationProgramModuleRequest.Id);
        EducationProgramModule educationProgramModule = _mapper.Map<EducationProgramModule>(updateEducationProgramModuleRequest);
        EducationProgramModule updatedEducationProgramModule = await _educationProgramModuleDal.UpdateAsync(educationProgramModule);
        UpdatedEducationProgramModuleResponse updatedEducationProgramModuleResponse = _mapper.Map<UpdatedEducationProgramModuleResponse>(updatedEducationProgramModule);
        return updatedEducationProgramModuleResponse;
    }
}
