﻿using AutoMapper;
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

namespace Business.Concretes
{
    public class OccupationClassManager : IOccupationClassService
    {

        IOccupationClassDal _occupationClassDal;
        IMapper _mapper;
        OccupationClassBusinessRules _occupationClassBusinessRules;
        public OccupationClassManager(IOccupationClassDal occupationClassDal, IMapper mapper, OccupationClassBusinessRules occupationClassBusinessRules)
        {
            _occupationClassDal = occupationClassDal;
            _mapper = mapper;
            _occupationClassBusinessRules = occupationClassBusinessRules;
        }

        public async Task<CreatedOccupationClassResponse> AddAsync(CreateOccupationClassRequest createOccupationClassRequest)
        {
            OccupationClass occupationClass = _mapper.Map<OccupationClass>(createOccupationClassRequest);
            OccupationClass createdOccupationClass = await _occupationClassDal.AddAsync(occupationClass);
            CreatedOccupationClassResponse createdOccupationClassResponse = _mapper.Map<CreatedOccupationClassResponse>(createdOccupationClass);
            return createdOccupationClassResponse;
        }

        public async Task<DeletedOccupationClassResponse> DeleteAsync(DeleteOccupationClassRequest deleteOccupationClassRequest)
        {
            await _occupationClassBusinessRules.IsExistsOccupationClass(deleteOccupationClassRequest.Id);
            OccupationClass occupationClass = await _occupationClassDal.GetAsync(predicate: o => o.Id == deleteOccupationClassRequest.Id);
            OccupationClass deletedOccupationClass = await _occupationClassDal.DeleteAsync(occupationClass, false);
            DeletedOccupationClassResponse deletedOccupationClassResponse = _mapper.Map<DeletedOccupationClassResponse>(deletedOccupationClass);
            return deletedOccupationClassResponse;
        }

        public async Task<GetListOccupationClassResponse> GetByIdAsync(Guid id)
        {
            var occupationClassId = await _occupationClassDal.GetAsync(o => o.Id == id);
            var mappedoccupationClass = _mapper.Map<GetListOccupationClassResponse>(occupationClassId);
            return mappedoccupationClass;
        }

        public async Task<IPaginate<GetListOccupationClassResponse>> GetListAsync(PageRequest pageRequest)
        {
            var occupationClasss = await _occupationClassDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);
            var mappedOccupationClasses = _mapper.Map<Paginate<GetListOccupationClassResponse>>(occupationClasss);
            return mappedOccupationClasses;
        }

        public async Task<UpdatedOccupationClassResponse> UpdateAsync(UpdateOccupationClassRequest updateOccupationClassRequest)
        {
            await _occupationClassBusinessRules.IsExistsOccupationClass(updateOccupationClassRequest.Id);
            OccupationClass occupationClass = _mapper.Map<OccupationClass>(updateOccupationClassRequest);
            OccupationClass updatedOccupationClass = await _occupationClassDal.UpdateAsync(occupationClass);
            UpdatedOccupationClassResponse updatedOccupationClassResponse = _mapper.Map<UpdatedOccupationClassResponse>(updatedOccupationClass);
            return updatedOccupationClassResponse;
        }
    }
}
