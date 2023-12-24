﻿using System;
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

namespace Business.Concretes;

public class SocialMediaManager : ISocialMediaService
{
    ISocialMediaDal _socialMediaDal;
    IMapper _mapper;
    SocialMediaBusinessRules _socialMediaBusinessRules;

    public SocialMediaManager(ISocialMediaDal socialMediaDal, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
    {
        _socialMediaDal = socialMediaDal;
        _mapper = mapper;
        _socialMediaBusinessRules = socialMediaBusinessRules;
    }

    public async Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest)
    {
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(createSocialMediaRequest);
        SocialMedia addedSocialMedia = await _socialMediaDal.AddAsync(socialMedia);
        CreatedSocialMediaResponse createdSocialMediaResponse = _mapper.Map<CreatedSocialMediaResponse>(addedSocialMedia);
        return createdSocialMediaResponse;
    }

    public async Task<DeletedSocialMediaResponse> DeleteAsync(DeleteSocialMediaRequest deleteSocialMediaRequest)
    {
        await _socialMediaBusinessRules.IsExistsSocialMedia(deleteSocialMediaRequest.Id);
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(deleteSocialMediaRequest);
        SocialMedia deletedSocialMedia = await _socialMediaDal.DeleteAsync(socialMedia);
        DeletedSocialMediaResponse deletedSocialMediaResponse = _mapper.Map<DeletedSocialMediaResponse>(deletedSocialMedia);
        return deletedSocialMediaResponse;
    }

    public async Task<IPaginate<GetListSocialMediaResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var socialMediaList = await _socialMediaDal.GetListAsync(
            include: s => s.Include(a => a.AccountSocialMedias).ThenInclude(asm=>asm.Account));
        var filteredSocialMedias = socialMediaList
            .Items.SelectMany(s => s.AccountSocialMedias.Where(a => a.AccountId == accountId).Select(a => s)).ToList();
        var mappedSocialMedias = _mapper.Map<Paginate<GetListSocialMediaResponse>>(socialMediaList);
        return mappedSocialMedias;
    }

    public async Task<GetListSocialMediaResponse> GetByIdAsync(Guid id)
    {
        var socialMedia = await _socialMediaDal.GetAsync(s => s.Id == id);
        var mappedSocialMedia = _mapper.Map<GetListSocialMediaResponse>(socialMedia);
        return mappedSocialMedia;
    }

    public async Task<IPaginate<GetListSocialMediaResponse>> GetListAsync()
    {
        var socialMedias = await _socialMediaDal.GetListAsync();
        var mappedSocialMedias = _mapper.Map<Paginate<GetListSocialMediaResponse>>(socialMedias);
        return mappedSocialMedias;
    }

    public async Task<UpdatedSocialMediaResponse> UpdateAsync(UpdateSocialMediaRequest updateSocialMediaRequest)
    {
        await _socialMediaBusinessRules.IsExistsSocialMedia(updateSocialMediaRequest.Id);
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaRequest);
        SocialMedia updatedSocialMedia = await _socialMediaDal.UpdateAsync(socialMedia);
        UpdatedSocialMediaResponse updatedSocialMediaResponse = _mapper.Map<UpdatedSocialMediaResponse>(updatedSocialMedia);
        return updatedSocialMediaResponse;
    }
}

