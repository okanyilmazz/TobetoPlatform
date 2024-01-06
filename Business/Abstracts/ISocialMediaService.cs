﻿using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISocialMediaService
{
    Task<IPaginate<GetListSocialMediaResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListSocialMediaResponse>> GetByAccountIdAsync(Guid Id);
    Task<GetListSocialMediaResponse> GetByIdAsync(Guid id);
    Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest);
    Task<DeletedSocialMediaResponse> DeleteAsync(DeleteSocialMediaRequest deleteSocialMediaRequest);
    Task<UpdatedSocialMediaResponse> UpdateAsync(UpdateSocialMediaRequest updateSocialMediaRequest);
}

