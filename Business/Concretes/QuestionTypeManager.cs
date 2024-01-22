using System;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.QuestionTypeRequests;
using Business.Dtos.Responses.QuestionTypeResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class QuestionTypeManager : IQuestionTypeService
    {

        IQuestionTypeDal _questionTypeDal;
        IMapper _mapper;
        QuestionTypeBusinessRules _questionTypeBusinessRules;

        public QuestionTypeManager(IQuestionTypeDal questionTypeDal, IMapper mapper, QuestionTypeBusinessRules questionTypeBusinessRules)
        {
            _questionTypeDal = questionTypeDal;
            _mapper = mapper;
            _questionTypeBusinessRules = questionTypeBusinessRules;
        }
        public async Task<CreatedQuestionTypeResponse> AddAsync(CreateQuestionTypeRequest createQuestionTypeRequest)
        {
            QuestionType questionType = _mapper.Map<QuestionType>(createQuestionTypeRequest);
            QuestionType addedQuestionType = await _questionTypeDal.AddAsync(questionType);
            CreatedQuestionTypeResponse createdQuestionTypeResponse = _mapper.Map<CreatedQuestionTypeResponse>(addedQuestionType);
            return createdQuestionTypeResponse;
        }

        public async Task<DeletedQuestionTypeResponse> DeleteAsync(DeleteQuestionTypeRequest deleteQuestionTypeRequest)
        {
            await _questionTypeBusinessRules.IsExistsQuestionType(deleteQuestionTypeRequest.Id);
            QuestionType questionType = await _questionTypeDal.GetAsync(predicate: q => q.Id == deleteQuestionTypeRequest.Id);
            QuestionType deletedQuestionType = await _questionTypeDal.DeleteAsync(questionType, false);
            DeletedQuestionTypeResponse deletedQuestionTypeResponse = _mapper.Map<DeletedQuestionTypeResponse>(deletedQuestionType);
            return deletedQuestionTypeResponse;
        }


        public async Task<IPaginate<GetListQuestionTypeResponse>> GetListAsync(PageRequest pageRequest)
        {
            var QuestionTypes = await _questionTypeDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
                );
            var mappedQuestionTypes = _mapper.Map<Paginate<GetListQuestionTypeResponse>>(QuestionTypes);
            return mappedQuestionTypes;
        }

        public async Task<UpdatedQuestionTypeResponse> UpdateAsync(UpdateQuestionTypeRequest updateQuestionTypeRequest)
        {
            await _questionTypeBusinessRules.IsExistsQuestionType(updateQuestionTypeRequest.Id);
            QuestionType questionType = _mapper.Map<QuestionType>(updateQuestionTypeRequest);
            QuestionType updatedQuestionType = await _questionTypeDal.UpdateAsync(questionType);
            UpdatedQuestionTypeResponse updatedQuestionTypeResponse = _mapper.Map<UpdatedQuestionTypeResponse>(updatedQuestionType);
            return updatedQuestionTypeResponse;
        }
    }
}

