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
    public class UniversityManager:IUniversityService
    {
        IUniversityDal _universityDal;
        IMapper _mapper;
        UniversityBusinessRules _universityBusinessRules;

        public UniversityManager(IUniversityDal universityDal, IMapper mapper, UniversityBusinessRules universityBusinessRules)
        {
            _universityDal = universityDal;
            _mapper = mapper;
            _universityBusinessRules = universityBusinessRules;
        }

        public async Task<CreatedUniversityResponse> AddAsync(CreateUniversityRequest createUniversityRequest)
        {
            University university = _mapper.Map<University>(createUniversityRequest);
            University addedUniversity = await _universityDal.AddAsync(university);
            CreatedUniversityResponse createdUniversityResponse = _mapper.Map<CreatedUniversityResponse>(addedUniversity);
            return createdUniversityResponse;
        }

        public async Task<DeletedUniversityResponse> DeleteAsync(DeleteUniversityRequest deleteUniversityRequest)
        {
            await _universityBusinessRules.IsExistsUniversity(deleteUniversityRequest.Id);
            University university = _mapper.Map<University>(deleteUniversityRequest);
            University deletedUniversity = await _universityDal.DeleteAsync(university);
            DeletedUniversityResponse deletedUniversityResponse = _mapper.Map<DeletedUniversityResponse>(deletedUniversity);
            return deletedUniversityResponse;
        }

        public async Task<IPaginate<GetListUniversityResponse>> GetListAsync()
        {
            var University = await _universityDal.GetListAsync();
            var mappedUniversity = _mapper.Map<Paginate<GetListUniversityResponse>>(University);
            return mappedUniversity;
        }

        public async Task<UpdatedUniversityResponse> UpdateAsync(UpdateUniversityRequest updateUniversityRequest)
        {
            await _universityBusinessRules.IsExistsUniversity(updateUniversityRequest.Id);
            University university = _mapper.Map<University>(updateUniversityRequest);
            University updatedUniversity = await _universityDal.UpdateAsync(university);
            UpdatedUniversityResponse updatedUniversityResponse = _mapper.Map<UpdatedUniversityResponse>(updatedUniversity);
            return updatedUniversityResponse;
        }
    }
}
