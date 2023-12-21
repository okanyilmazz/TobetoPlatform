using System;
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

namespace Business.Concretes;

public class CountryManager : ICountryService
{
    ICountryDal _countryDal;
    IMapper _mapper;
    CountryBusinessRules _countryBusinessRules;

    public CountryManager(ICountryDal countryDal, IMapper mapper, CountryBusinessRules countryBusinessRules)
    {
        _countryDal = countryDal;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<CreatedCountryResponse> AddAsync(CreateCountryRequest createCountryRequest)
    {
        Country country = _mapper.Map<Country>(createCountryRequest);
        Country addedCountry = await _countryDal.AddAsync(country);
        var responseCountry = _mapper.Map<CreatedCountryResponse>(addedCountry);
        return responseCountry;
    }

    public async Task<DeletedCountryResponse> DeleteAsync(DeleteCountryRequest deleteCountryRequest)
    {
        await _countryBusinessRules.IsExistsCountry(deleteCountryRequest.Id);
        Country country = _mapper.Map<Country>(deleteCountryRequest);
        Country deletedCountry = await _countryDal.DeleteAsync(country, true);
        DeletedCountryResponse deletedCountryResponse = _mapper.Map<DeletedCountryResponse>(deletedCountry);
        return deletedCountryResponse;
    }

    public async Task<IPaginate<GetListCountryResponse>> GetListAsync()
    {
        var Countries = await _countryDal.GetListAsync();
        var mappedCountries = _mapper.Map<Paginate<GetListCountryResponse>>(Countries);
        return mappedCountries;
    }

    public async Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest updateCountryRequest)
    {   await _countryBusinessRules.IsExistsCountry(updateCountryRequest.Id);
        Country country = _mapper.Map<Country>(updateCountryRequest);
        Country updatedCountry = await _countryDal.UpdateAsync(country);
        UpdatedCountryResponse updatedCountryResponse = _mapper.Map<UpdatedCountryResponse>(updatedCountry);
        return updatedCountryResponse;
    }
}

