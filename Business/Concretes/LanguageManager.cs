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
            Language language = await _languageDal.GetAsync(predicate: l => l.Id == deleteLanguageRequest.Id);
            var deletedLanguage = await _languageDal.DeleteAsync(language);
            var responseLanguage = _mapper.Map<DeletedLanguageResponse>(deletedLanguage);
            return responseLanguage;
        }

        public async Task<GetListLanguageResponse> GetByIdAsync(Guid id)
        {
            var language = await _languageDal.GetListAsync(l => l.Id == id);
            return _mapper.Map<GetListLanguageResponse>(language.Items.FirstOrDefault());
        }

        public async Task<IPaginate<GetListLanguageResponse>> GetListAsync()
        {
            var languageListed = await _languageDal.GetListAsync();
            var mappedListed = _mapper.Map<Paginate<GetListLanguageResponse>>(languageListed);
            return mappedListed;
        }
        public async Task<IPaginate<GetListLanguageResponse>> GetByAccountIdAsync(Guid accountId)
        {
            var languages = await _languageDal.GetListAsync(
                include: l => l.Include(a => a.AccountLanguages).ThenInclude(al=>al.Account));
            var filteredLanguages = languages.Items.SelectMany(l => l.AccountLanguages.Where(a => a.AccountId == accountId).Select(a => l)).ToList();
            var mappedLanguages = _mapper.Map<Paginate<GetListLanguageResponse>>(filteredLanguages);
            return mappedLanguages;
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