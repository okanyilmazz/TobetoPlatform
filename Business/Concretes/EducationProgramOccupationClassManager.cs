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
    public class EducationProgramOccupationClassManager : IEducationProgramOccupationClassService
    {

        IEducationProgramOccupationClassDal _educationProgramOccupationClassDal;
        IMapper _mapper;
        EducationProgramOccupationClassBusinessRules _educationProgramOccupationClassBusinessRules;

        public EducationProgramOccupationClassManager(IEducationProgramOccupationClassDal educationProgramOccupationClassDal, IMapper mapper, EducationProgramOccupationClassBusinessRules educationProgramOccupationClassBusinessRules)
        {
            _educationProgramOccupationClassDal = educationProgramOccupationClassDal;
            _mapper = mapper;
            _educationProgramOccupationClassBusinessRules = educationProgramOccupationClassBusinessRules;
        }

        public async Task<CreatedEducationProgramOccupationClassResponse> AddAsync(CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest)
        {
            EducationProgramOccupationClass EducationProgramOccupationClass = _mapper.Map<EducationProgramOccupationClass>(createEducationProgramOccupationClassRequest);
            EducationProgramOccupationClass createdEducationProgramOccupationClass = await _educationProgramOccupationClassDal.AddAsync(EducationProgramOccupationClass);
            CreatedEducationProgramOccupationClassResponse createdEducationProgramOccupationClassResponse = _mapper.Map<CreatedEducationProgramOccupationClassResponse>(createdEducationProgramOccupationClass);
            return createdEducationProgramOccupationClassResponse;
        }

        public async Task<DeletedEducationProgramOccupationClassResponse> DeleteAsync(DeleteEducationProgramOccupationClassRequest deleteEducationProgramOccupationClassRequest)
        {
            await _educationProgramOccupationClassBusinessRules.IsExistsEducationProgramOccupationClass(deleteEducationProgramOccupationClassRequest.Id);
            EducationProgramOccupationClass EducationProgramOccupationClass = _mapper.Map<EducationProgramOccupationClass>(deleteEducationProgramOccupationClassRequest);
            EducationProgramOccupationClass deletedEducationProgramOccupationClass = await _educationProgramOccupationClassDal.DeleteAsync(EducationProgramOccupationClass);
            DeletedEducationProgramOccupationClassResponse deletedEducationProgramOccupationClassResponse = _mapper.Map<DeletedEducationProgramOccupationClassResponse>(deletedEducationProgramOccupationClass);
            return deletedEducationProgramOccupationClassResponse;
        }

        public async Task<GetListEducationProgramOccupationClassResponse> GetByIdAsync(Guid id)
        {
            var educationProgramOccupationClass = await _educationProgramOccupationClassDal.GetListAsync(h => h.Id == id);
            return _mapper.Map<GetListEducationProgramOccupationClassResponse>(educationProgramOccupationClass.Items.FirstOrDefault());
        }

        public async Task<IPaginate<GetListEducationProgramOccupationClassResponse>> GetListAsync()
        {
            var EducationProgramOccupationClasss = await _educationProgramOccupationClassDal.GetListAsync();
            var mappedEducationProgramOccupationClasses = _mapper.Map<Paginate<GetListEducationProgramOccupationClassResponse>>(EducationProgramOccupationClasss);
            return mappedEducationProgramOccupationClasses;
        }

        public async Task<UpdatedEducationProgramOccupationClassResponse> UpdateAsync(UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest)
        {
             await _educationProgramOccupationClassBusinessRules.IsExistsEducationProgramOccupationClass(updateEducationProgramOccupationClassRequest.Id);
            EducationProgramOccupationClass EducationProgramOccupationClass = _mapper.Map<EducationProgramOccupationClass>(updateEducationProgramOccupationClassRequest);
            EducationProgramOccupationClass updatedEducationProgramOccupationClass = await _educationProgramOccupationClassDal.UpdateAsync(EducationProgramOccupationClass);
            UpdatedEducationProgramOccupationClassResponse updatedEducationProgramOccupationClassResponse = _mapper.Map<UpdatedEducationProgramOccupationClassResponse>(updatedEducationProgramOccupationClass);
            return updatedEducationProgramOccupationClassResponse;
        }
    }
}
