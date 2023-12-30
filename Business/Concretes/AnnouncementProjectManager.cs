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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class AnnouncementProjectManager : IAnnouncementProjectService
{
    IAnnouncementProjectDal _announcementProjectDal;
    IMapper _mapper;
    AnnouncementProjectBusinessRules _announcementProjectBusinessRules;

    public AnnouncementProjectManager(IAnnouncementProjectDal announcementProjectDal, IMapper mapper, AnnouncementProjectBusinessRules announcementProjectBusinessRules)
    {
        _announcementProjectDal = announcementProjectDal;
        _mapper = mapper;
        _announcementProjectBusinessRules = announcementProjectBusinessRules;
    }

    public async Task<CreatedAnnouncementProjectResponse> AddAsync(CreateAnnouncementProjectRequest createAnnouncementProjectRequest)
    {
        AnnouncementProject announcementProject = _mapper.Map<AnnouncementProject>(createAnnouncementProjectRequest);
        AnnouncementProject addedAnnouncementProject = await _announcementProjectDal.AddAsync(announcementProject);
        CreatedAnnouncementProjectResponse createdAnnouncementProjectResponse = _mapper.Map<CreatedAnnouncementProjectResponse>(addedAnnouncementProject);
        return createdAnnouncementProjectResponse;

    }

    public async Task<DeletedAnnouncementProjectResponse> DeleteAsync(DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest)
    {
        await _announcementProjectBusinessRules.IsExistsAnnouncementProject(deleteAnnouncementProjectRequest.Id);
        AnnouncementProject announcementProject = _mapper.Map<AnnouncementProject>(deleteAnnouncementProjectRequest);
        AnnouncementProject deletedAnnouncemenProject = await _announcementProjectDal.DeleteAsync(announcementProject);
        DeletedAnnouncementProjectResponse deletedAnnouncementProjectResponse = _mapper.Map<DeletedAnnouncementProjectResponse>(deletedAnnouncemenProject);
        return deletedAnnouncementProjectResponse;
    }

    public async Task<GetListAnnouncementProjectResponse> GetByIdAsync(Guid Id)
    {
        var announcementProject = await _announcementProjectDal.GetAsync(
            predicate:a=> a.Id == Id,
            include: ap=> ap
            .Include(ap=>ap.Announcement)
            .Include(ap=>ap.Project)
            );
        var mappedAnnouncementProject = _mapper.Map<GetListAnnouncementProjectResponse>(announcementProject);
        return mappedAnnouncementProject;
    }

    public async Task<IPaginate<GetListAnnouncementProjectResponse>> GetListAsync()
    {
        var announcementProject = await _announcementProjectDal.GetListAsync(
             include: ap => ap
            .Include(ap => ap.Announcement)
            .Include(ap => ap.Project));
        var mappedAnnouncementProject = _mapper.Map<Paginate<GetListAnnouncementProjectResponse>>(announcementProject);
        return mappedAnnouncementProject;
    }

    public async Task<UpdatedAnnouncementProjectResponse> UpdateAsync(UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest)
    {
        await _announcementProjectBusinessRules.IsExistsAnnouncementProject(updateAnnouncementProjectRequest.Id);
        AnnouncementProject announcementProject = _mapper.Map<AnnouncementProject>(updateAnnouncementProjectRequest);
        AnnouncementProject updatedAnnouncemenProject = await _announcementProjectDal.UpdateAsync(announcementProject);
        UpdatedAnnouncementProjectResponse updatedAnnouncementProjectResponse = _mapper.Map<UpdatedAnnouncementProjectResponse>(updatedAnnouncemenProject);
        return updatedAnnouncementProjectResponse;
    }
}

