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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UniversityDepartmentManager : IUniversityDepartmentService
    {
        IUniversityDepartmentDal _universityDepartmentDal;
        IMapper _mapper;
        UniversityDepartmentBusinessRules _universityDepartmentRules;

        public UniversityDepartmentManager(IUniversityDepartmentDal universityDepartmentDal, IMapper mapper, UniversityDepartmentBusinessRules universityDepartmentRules)
        {
            _universityDepartmentDal = universityDepartmentDal;
            _mapper = mapper;
            _universityDepartmentRules = universityDepartmentRules;
        }

        public async Task<CreatedUniversityDepartmentResponse> AddAsync(CreateUniversityDepartmentRequest createUniversityDepartmentRequest)
        {
            UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(createUniversityDepartmentRequest);
            UniversityDepartment addedUniversityDepartment = await _universityDepartmentDal.AddAsync(universityDepartment);
            CreatedUniversityDepartmentResponse createdUniversityDepartmentResponse = _mapper.Map<CreatedUniversityDepartmentResponse>(addedUniversityDepartment);
            return createdUniversityDepartmentResponse;

        }

        public async Task<DeletedUniversityDepartmentResponse> DeleteAsync(DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest)
        {
            await _universityDepartmentRules.IsExistsUniversityDepartment(deleteUniversityDepartmentRequest.Id);
            UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(deleteUniversityDepartmentRequest);
            UniversityDepartment deletedUniversityDepartment = await _universityDepartmentDal.DeleteAsync(universityDepartment);
            DeletedUniversityDepartmentResponse deletedUniversityDepartmentResponse = _mapper.Map<DeletedUniversityDepartmentResponse>(deletedUniversityDepartment);
            return deletedUniversityDepartmentResponse;
        }

        public async Task<IPaginate<GetListUniversityDepartmentResponse>> GetListAsync()
        {
            var universityDepartment = await _universityDepartmentDal.GetListAsync();
            var mappedUniversityDepartment = _mapper.Map<Paginate<GetListUniversityDepartmentResponse>>(universityDepartment);
            return mappedUniversityDepartment;
        }

        public async Task<UpdatedUniversityDepartmentResponse> UpdateAsync(UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest)
        {
            await _universityDepartmentRules.IsExistsUniversityDepartment(updateUniversityDepartmentRequest.Id);
            UniversityDepartment universityDepartment = _mapper.Map<UniversityDepartment>(updateUniversityDepartmentRequest);
            UniversityDepartment updatedUniversityDepartment = await _universityDepartmentDal.UpdateAsync(universityDepartment);
            UpdatedUniversityDepartmentResponse updatedUniversityDepartmentResponse = _mapper.Map<UpdatedUniversityDepartmentResponse>(updatedUniversityDepartment);
            return updatedUniversityDepartmentResponse;
        }

    }
}
