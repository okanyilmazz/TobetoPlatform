using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class WorkExperienceManager : IWorkExperienceService
{
    IWorkExperienceDal _workExperienceDal;
    IMapper _mapper;

    public WorkExperienceManager(IWorkExperienceDal workExperienceDal, IMapper mapper)
    {
        _workExperienceDal = workExperienceDal;
        _mapper = mapper;
    }
    public async Task<CreatedWorkExperienceResponse> AddAsync(CreateWorkExperienceRequest createWorkExperienceRequest)
    {
        WorkExperience workExperience = _mapper.Map<WorkExperience>(createWorkExperienceRequest);
        WorkExperience addedWorkExperience = await _workExperienceDal.AddAsync(workExperience);
        CreatedWorkExperienceResponse createdWorkExperienceResponse = _mapper.Map<CreatedWorkExperienceResponse>(addedWorkExperience);
        return createdWorkExperienceResponse;
    }

    public async Task<DeletedWorkExperienceResponse> DeleteAsync(DeleteWorkExperienceRequest deleteWorkExperienceRequest)
    {
        WorkExperience workExperience = _mapper.Map<WorkExperience>(deleteWorkExperienceRequest);
        WorkExperience deletedWorkExperience = await _workExperienceDal.DeleteAsync(workExperience);
        DeletedWorkExperienceResponse deletedWorkExperienceResponse = _mapper.Map<DeletedWorkExperienceResponse>(deletedWorkExperience);
        return deletedWorkExperienceResponse;
    }

    public async Task<IPaginate<GetListWorkExperienceResponse>> GetListAsync()
    {
        var workExperience = await _workExperienceDal.GetListAsync(
                include: we => we
                .Include(we => we.City)
                .Include(we => we.Account).ThenInclude(we=>we.User));

        var mappedWorkExperience = _mapper.Map<Paginate<GetListWorkExperienceResponse>>(workExperience);
        return mappedWorkExperience;
    }

    public async Task<GetListWorkExperienceResponse> GetByIdAsync(Guid id)
    {
        var workExperience = await _workExperienceDal.GetAsync(
            predicate: we => we.Id == id,
            include: we => we
            .Include(we => we.City)
            .Include(we => we.Account).ThenInclude(we => we.User));
            
        var mappedWorkExperience = _mapper.Map<GetListWorkExperienceResponse>(workExperience);
        return mappedWorkExperience;
    }

    public async Task<UpdatedWorkExperienceResponse> UpdateAsync(UpdateWorkExperienceRequest updateWorkExperienceRequest)
    {
        WorkExperience workExperience = _mapper.Map<WorkExperience>(updateWorkExperienceRequest);
        WorkExperience updatedWorkExperience = await _workExperienceDal.UpdateAsync(workExperience);
        UpdatedWorkExperienceResponse updatedWorkExperienceResponse = _mapper.Map<UpdatedWorkExperienceResponse>(updatedWorkExperience);
        return updatedWorkExperienceResponse;
    }
}
