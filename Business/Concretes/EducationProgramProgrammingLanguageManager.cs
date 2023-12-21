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
    public class EducationProgramProgrammingLanguageManager : IEducationProgramProgrammingLanguageService
    {
        IEducationProgramProgrammingLanguageDal _educationProgramLanguageProgrammingDal;
        IMapper _mapper;
        EducationProgramProgrammingLanguageBusinessRules _educationProgramLanguageProgrammingBusinessRules;

        public EducationProgramProgrammingLanguageManager(IEducationProgramProgrammingLanguageDal educationProgramLanguageProgrammingDal, IMapper mapper, EducationProgramProgrammingLanguageBusinessRules educationProgramLanguageProgrammingBusinessRules)
        {
            _educationProgramLanguageProgrammingDal = educationProgramLanguageProgrammingDal;
            _mapper = mapper;
            _educationProgramLanguageProgrammingBusinessRules = educationProgramLanguageProgrammingBusinessRules;
        }

        public async Task<CreatedEducationProgramProgrammingLanguageResponse> AddAsync(CreateEducationProgramProgrammingLanguageRequest createEducationProgramProgrammingLanguageRequest)
        {
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(createEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage addedEducationProgramProgrammingLanguage = await _educationProgramLanguageProgrammingDal.AddAsync(educationProgramLanguageProgramming);
            CreatedEducationProgramProgrammingLanguageResponse createdEducationProgramProgrammingLanguageResponse = _mapper.Map<CreatedEducationProgramProgrammingLanguageResponse>(addedEducationProgramProgrammingLanguage);
            return createdEducationProgramProgrammingLanguageResponse;
        }

        public async Task<DeletedEducationProgramProgrammingLanguageResponse> DeleteAsync(DeleteEducationProgramProgrammingLanguageRequest deleteEducationProgramProgrammingLanguageRequest)
        {
            await _educationProgramLanguageProgrammingBusinessRules.IsExistsEducationProgramProgrammingLanguage(deleteEducationProgramProgrammingLanguageRequest.Id);
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(deleteEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage deletedEducationProgramProgrammingLanguage = await _educationProgramLanguageProgrammingDal.DeleteAsync(educationProgramLanguageProgramming, true);
            DeletedEducationProgramProgrammingLanguageResponse deletedEducationProgramProgrammingLanguageResponse = _mapper.Map<DeletedEducationProgramProgrammingLanguageResponse>(deletedEducationProgramProgrammingLanguage);
            return deletedEducationProgramProgrammingLanguageResponse;
        }

        public async Task<IPaginate<GetListEducationProgramProgrammingLanguageResponse>> GetListAsync()
        {
            var EducationProgramProgrammingLanguages = await _educationProgramLanguageProgrammingDal.GetListAsync();
            var mappedEducationProgramProgrammingLanguages = _mapper.Map<Paginate<GetListEducationProgramProgrammingLanguageResponse>>(EducationProgramProgrammingLanguages);
            return mappedEducationProgramProgrammingLanguages;
        }

        public async Task<UpdatedEducationProgramProgrammingLanguageResponse> UpdateAsync(UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest)
        {
            await _educationProgramLanguageProgrammingBusinessRules.IsExistsEducationProgramProgrammingLanguage(updateEducationProgramProgrammingLanguageRequest.Id);
            EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(updateEducationProgramProgrammingLanguageRequest);
            EducationProgramProgrammingLanguage updatedEducationProgramProgrammingLanguage = await _educationProgramLanguageProgrammingDal.UpdateAsync(educationProgramLanguageProgramming);
            UpdatedEducationProgramProgrammingLanguageResponse updatedEducationProgramProgrammingLanguageResponse = _mapper.Map<UpdatedEducationProgramProgrammingLanguageResponse>(updatedEducationProgramProgrammingLanguage);
            return updatedEducationProgramProgrammingLanguageResponse;
        }
    }
}
