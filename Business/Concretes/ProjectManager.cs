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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProjectManager : IProjectService
{
    IProjectDal _projectDal;
    IMapper _mapper;

    public ProjectManager(IProjectDal projectDal, IMapper mapper)
    {
        _projectDal = projectDal;
        _mapper = mapper;
    }
    public async Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest)
    {
        Project project = _mapper.Map<Project>(createProjectRequest);
        Project addedProject = await _projectDal.AddAsync(project);
        CreatedProjectResponse responseProject = _mapper.Map<CreatedProjectResponse>(addedProject);
        return responseProject;
    }

    public async Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest)
    {
        Project project = _mapper.Map<Project>(updateProjectRequest);
        Project updatedProject = await _projectDal.UpdateAsync(project);
        UpdatedProjectResponse responseProject = _mapper.Map<UpdatedProjectResponse>(updatedProject);
        return responseProject;
    }

    public async Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest)
    {
        Project project = _mapper.Map<Project>(deleteProjectRequest);
        Project deletedProject = await _projectDal.DeleteAsync(project,true);
        DeletedProjectResponse responseProject = _mapper.Map<DeletedProjectResponse>(deletedProject);
        return responseProject;
    }

    public async Task<IPaginate<GetListProjectResponse>> GetListAsync()
    {
        var projectListed = await _projectDal.GetListAsync();
        var mappedListed = _mapper.Map<Paginate<GetListProjectResponse>>(projectListed);
        return mappedListed;
    }
}
