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
    public class LanguageManager : ILanguageService
    {
        ILanguageDal _languageDal;
        IMapper _mapper;
        LanguageBusinessRules _languageBusinessRules;

        public LanguageManager(ILanguageDal languageDal,IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            _languageDal = languageDal;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedLanguageResponse> AddAsync(CreateLanguageRequest createLanguageRequest)
        {
            var language = _mapper.Map<Language>(createLanguageRequest);
            var addedLanguage = await _languageDal.AddAsync(language);
            var responseLanguage = _mapper.Map<CreatedLanguageResponse>(addedLanguage);
            return responseLanguage;
        }

        public async Task<DeletedLanguageResponse> DeleteAsync(DeleteLanguageRequest deleteLanguageRequest)
        {
            await _languageBusinessRules.IsExistsLanguage(deleteLanguageRequest.Id);
            var language = _mapper.Map<Language>(deleteLanguageRequest);
            var deletedLanguage = await _languageDal.DeleteAsync(language);
            var responseLanguage = _mapper.Map<DeletedLanguageResponse>(deletedLanguage);
            return responseLanguage;
        }

        public async Task<IPaginate<GetListLanguageResponse>> GetListAsync()
        {
            var languageListed = await _languageDal.GetListAsync();
            var mappedListed = _mapper.Map<Paginate<GetListLanguageResponse>>(languageListed);
            return mappedListed;
        }

        public async Task<UpdatedLanguageResponse> UpdateAsync(UpdateLanguageRequest updateLanguageRequest)
        {
            await _languageBusinessRules.IsExistsLanguage(updateLanguageRequest.Id);
            var language = _mapper.Map<Language>(updateLanguageRequest);
            var updatedLanguage = await _languageDal.UpdateAsync(language);
            var responseLanguage = _mapper.Map<UpdatedLanguageResponse>(updatedLanguage);
            return responseLanguage;
        }
    }
}