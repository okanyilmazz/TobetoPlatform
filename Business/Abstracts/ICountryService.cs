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

public interface ICountryService
{
    Task<CreatedCountryResponse> AddAsync(CreateCountryRequest createCountryRequest);
    Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest updateCountryRequest);
    Task<DeletedCountryResponse> DeleteAsync(DeleteCountryRequest deleteCountryRequest);
    Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCountryResponse> GetByIdAsync(Guid id);
}
