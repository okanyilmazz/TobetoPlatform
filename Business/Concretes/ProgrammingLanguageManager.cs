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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProgrammingLanguageManager : IProgrammingLanguageService
    {
        IProgrammingLanguageDal _programmingLanguageDal;
        IMapper _mapper;
        ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public ProgrammingLanguageManager(IProgrammingLanguageDal programmingLanguageDal, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageDal = programmingLanguageDal;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageResponse> AddAsync(CreateProgrammingLanguageRequest createProgrammingLanguageRequest)
        {
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(createProgrammingLanguageRequest);
            ProgrammingLanguage addedProgrammingLanguage = await _programmingLanguageDal.AddAsync(programmingLanguage);
            CreatedProgrammingLanguageResponse createdProgrammingLanguageResponse = _mapper.Map<CreatedProgrammingLanguageResponse>(addedProgrammingLanguage);
            return createdProgrammingLanguageResponse;
        }

        public async Task<DeletedProgrammingLanguageResponse> DeleteAsync(DeleteProgrammingLanguageRequest deleteProgrammingLanguageRequest)
        {
            await _programmingLanguageBusinessRules.IsExistsProgrammingLanguage(deleteProgrammingLanguageRequest.Id);
            ProgrammingLanguage programmingLanguage = await _programmingLanguageDal.GetAsync(predicate: a => a.Id == deleteProgrammingLanguageRequest.Id);
            ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageDal.DeleteAsync(programmingLanguage, false);
            DeletedProgrammingLanguageResponse createdProgrammingLanguageResponse = _mapper.Map<DeletedProgrammingLanguageResponse>(deletedProgrammingLanguage);
            return createdProgrammingLanguageResponse;
        }

        public async Task<IPaginate<GetListProgrammingLanguageResponse>> GetListAsync()
        {
            var programmingLanguages = await _programmingLanguageDal.GetListAsync();
            var mappedProgrammingLanguages = _mapper.Map<Paginate<GetListProgrammingLanguageResponse>>(programmingLanguages);
            return mappedProgrammingLanguages;
        }

        public async Task<GetListProgrammingLanguageResponse> GetByIdAsync(Guid id)
        {
            var programmingLanguage = await _programmingLanguageDal.GetAsync(p => p.Id == id);
            var mappedProgrammingLanguage = _mapper.Map<GetListProgrammingLanguageResponse>(programmingLanguage);
            return mappedProgrammingLanguage;
        }

        public async Task<UpdatedProgrammingLanguageResponse> UpdateAsync(UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest)
        {
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(updateProgrammingLanguageRequest);
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageDal.UpdateAsync(programmingLanguage);
            UpdatedProgrammingLanguageResponse updatedProgrammingLanguageResponse = _mapper.Map<UpdatedProgrammingLanguageResponse>(updatedProgrammingLanguage);
            return updatedProgrammingLanguageResponse;
        }
    }
}
