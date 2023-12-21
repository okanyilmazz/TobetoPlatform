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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        IMapper _mapper;
        AnnouncementBusinessRules _announcementBusinessRules;

        public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper, AnnouncementBusinessRules announcementBusinessRules)
        {
            _announcementDal = announcementDal;
            _mapper = mapper;
            _announcementBusinessRules = announcementBusinessRules;
        }

        public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
            Announcement addedAnnouncement = await _announcementDal.AddAsync(announcement);
            CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(addedAnnouncement);
            return createdAnnouncementResponse;

        }

        public async Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest)
        {
            await _announcementBusinessRules.IsExistsAnnouncement(deleteAnnouncementRequest.Id);
            Announcement announcement = _mapper.Map<Announcement>(deleteAnnouncementRequest);
            Announcement deletedAnnouncemenProject = await _announcementDal.DeleteAsync(announcement);
            DeletedAnnouncementResponse deletedAnnouncementResponse = _mapper.Map<DeletedAnnouncementResponse>(deletedAnnouncemenProject);
            return deletedAnnouncementResponse;
        }

        public async Task<IPaginate<GetListAnnouncementResponse>> GetListAsync()
        {
            var announcement = await _announcementDal.GetListAsync(
                include: a => a.Include(p => p.Projects));
            var mappedAnnouncement = _mapper.Map<Paginate<GetListAnnouncementResponse>>(announcement);
            return mappedAnnouncement;
        }

        public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            await _announcementBusinessRules.IsExistsAnnouncement(updateAnnouncementRequest.Id);
            Announcement announcement = _mapper.Map<Announcement>(updateAnnouncementRequest);
            Announcement updatedAnnouncemenProject = await _announcementDal.UpdateAsync(announcement);
            UpdatedAnnouncementResponse updatedAnnouncementResponse = _mapper.Map<UpdatedAnnouncementResponse>(updatedAnnouncemenProject);
            return updatedAnnouncementResponse;
        }
    }
}

