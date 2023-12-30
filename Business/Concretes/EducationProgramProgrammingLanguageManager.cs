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
    public class EducationProgramProgrammingLanguageManager : IEducationProgramProgrammingLanguageService
    {
        IEducationProgramProgrammingLanguageDal _educationProgramProgrammingLanguageDal;
        IMapper _mapper;
        EducationProgramProgrammingLanguageBusinessRules _educationProgramProgrammingLanguageBusinessRules;

        public EducationProgramProgrammingLanguageManager(IEducationProgramProgrammingLanguageDal educationProgramProgrammingLanguageDal, IMapper mapper, EducationProgramProgrammingLanguageBusinessRules educationProgramProgrammingLanguageBusinessRules)
        {
            _educationProgramProgrammingLanguageDal = educationProgramProgrammingLanguageDal;
            _mapper = mapper;
            _educationProgramProgrammingLanguageBusinessRules = educationProgramProgrammingLanguageBusinessRules;
        }

        public async Task<CreatedEducationProgramProgrammingLanguageResponse> AddAsync(CreateEducationProgramProgrammingLanguageRequest createEducationProgramProgrammingLanguageRequest)
        {
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(createEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage addedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.AddAsync(educationProgramLanguageProgramming);
            CreatedEducationProgramProgrammingLanguageResponse createdEducationProgramProgrammingLanguageResponse = _mapper.Map<CreatedEducationProgramProgrammingLanguageResponse>(addedEducationProgramProgrammingLanguage);
            return createdEducationProgramProgrammingLanguageResponse;
        }

        public async Task<DeletedEducationProgramProgrammingLanguageResponse> DeleteAsync(DeleteEducationProgramProgrammingLanguageRequest deleteEducationProgramProgrammingLanguageRequest)
        {
            await _educationProgramProgrammingLanguageBusinessRules.IsExistsEducationProgramProgrammingLanguage(deleteEducationProgramProgrammingLanguageRequest.Id);
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(deleteEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage deletedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.DeleteAsync(educationProgramLanguageProgramming, true);
            DeletedEducationProgramProgrammingLanguageResponse deletedEducationProgramProgrammingLanguageResponse = _mapper.Map<DeletedEducationProgramProgrammingLanguageResponse>(deletedEducationProgramProgrammingLanguage);
            return deletedEducationProgramProgrammingLanguageResponse;
        }

        public async Task<GetListEducationProgramProgrammingLanguageResponse> GetByIdAsync(Guid id)
        {
            var EducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.GetAsync(
                predicate: p => p.Id == id,
                include: ep => ep
                .Include(ep => ep.EducationProgram)
                .Include(ep => ep.ProgrammingLanguage));
            var mappedEducationProgramProgrammingLanguage = _mapper.Map<GetListEducationProgramProgrammingLanguageResponse>(EducationProgramProgrammingLanguage);
            return mappedEducationProgramProgrammingLanguage;
        }

        public async Task<IPaginate<GetListEducationProgramProgrammingLanguageResponse>> GetListAsync()
        {
            var EducationProgramProgrammingLanguages = await _educationProgramProgrammingLanguageDal.GetListAsync(
                include: ep => ep
                .Include(ep => ep.EducationProgram)
                .Include(ep => ep.ProgrammingLanguage));
            var mappedEducationProgramProgrammingLanguages = _mapper.Map<Paginate<GetListEducationProgramProgrammingLanguageResponse>>(EducationProgramProgrammingLanguages);
            return mappedEducationProgramProgrammingLanguages;
        }

        public async Task<UpdatedEducationProgramProgrammingLanguageResponse> UpdateAsync(UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest)
        {
            await _educationProgramProgrammingLanguageBusinessRules.IsExistsEducationProgramProgrammingLanguage(updateEducationProgramProgrammingLanguageRequest.Id);
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(updateEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage updatedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.UpdateAsync(educationProgramLanguageProgramming);
            UpdatedEducationProgramProgrammingLanguageResponse updatedEducationProgramProgrammingLanguageResponse = _mapper.Map<UpdatedEducationProgramProgrammingLanguageResponse>(updatedEducationProgramProgrammingLanguage);
            return updatedEducationProgramProgrammingLanguageResponse;
        }
    }
}
