using System;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
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

        public QuestionTypeManager(IQuestionTypeDal questionTypeDal, IMapper mapper)
        {
            _questionTypeDal = questionTypeDal;
            _mapper = mapper;
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
            QuestionType questionType = await _questionTypeDal.GetAsync(predicate: q => q.Id == deleteQuestionTypeRequest.Id);
            QuestionType deletedQuestionType = await _questionTypeDal.DeleteAsync(questionType,false);
            DeletedQuestionTypeResponse deletedQuestionTypeResponse = _mapper.Map<DeletedQuestionTypeResponse>(deletedQuestionType);
            return deletedQuestionTypeResponse;
        }


        public async Task<IPaginate<GetListQuestionTypeResponse>> GetListAsync()
        {
            var QuestionTypes = await _questionTypeDal.GetListAsync();
            var mappedQuestionTypes = _mapper.Map<Paginate<GetListQuestionTypeResponse>>(QuestionTypes);
            return mappedQuestionTypes;
        }

        public async Task<UpdatedQuestionTypeResponse> UpdateAsync(UpdateQuestionTypeRequest updateQuestionTypeRequest)
        {
            QuestionType questionType = _mapper.Map<QuestionType>(updateQuestionTypeRequest);
            QuestionType updatedQuestionType = await _questionTypeDal.UpdateAsync(questionType);
            UpdatedQuestionTypeResponse updatedQuestionTypeResponse = _mapper.Map<UpdatedQuestionTypeResponse>(updatedQuestionType);
            return updatedQuestionTypeResponse;
        }
    }
}

