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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _districtDal;
        IMapper _mapper;
        DistrictBusinessRules _districtBusinessRules;

        public DistrictManager(IDistrictDal districtDal, IMapper mapper, DistrictBusinessRules districtBusinessRules)
        {
            _districtDal = districtDal;
            _mapper = mapper;
            _districtBusinessRules = districtBusinessRules;
        }



        public async Task<CreatedDistrictResponse> AddAsync(CreateDistrictRequest createDistrictRequest)
        {
            District district = _mapper.Map<District>(createDistrictRequest);
            District createdDistrict = await _districtDal.AddAsync(district);
            CreatedDistrictResponse createdDistrictResponse = _mapper.Map<CreatedDistrictResponse>(createdDistrict);
            return createdDistrictResponse;
        }

        public async Task<DeletedDistrictResponse> DeleteAsync(DeleteDistrictRequest deleteDistrictRequest)
        {
            await _districtBusinessRules.IsExistsDistrict(deleteDistrictRequest.Id);
            District district = _mapper.Map<District>(deleteDistrictRequest);
            District deletedDistrict = await _districtDal.DeleteAsync(district);
            DeletedDistrictResponse deletedDistrictResponse = _mapper.Map<DeletedDistrictResponse>(deletedDistrict);
            return deletedDistrictResponse;
        }

        public async Task<IPaginate<GetListDistrictResponse>> GetListAsync()
        {
            var district = await _districtDal.GetListAsync();
            var mappedDistrict = _mapper.Map<Paginate<GetListDistrictResponse>>(district);
            return mappedDistrict;
        }

        public async Task<UpdatedDistrictResponse> UpdateAsync(UpdateDistrictRequest updateDistrictRequest)
        {
            await _districtBusinessRules.IsExistsDistrict(updateDistrictRequest.Id);
            District district = _mapper.Map<District>(updateDistrictRequest);
            District updatedDistrict = await _districtDal.UpdateAsync(district);
            UpdatedDistrictResponse updatedDistrictResponse = _mapper.Map<UpdatedDistrictResponse>(updatedDistrict);
            return updatedDistrictResponse;
        }
    }
}
