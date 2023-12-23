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
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ExamResultManager : IExamResultService
    {
        IExamResultDal _examResultDal;
        IMapper _mapper;
        ExamResultBusinessRules _examResultBusinessRules;

        public ExamResultManager(IExamResultDal examResultDal, IMapper mapper, ExamResultBusinessRules examResultBusinessRules)
        {
            _examResultDal = examResultDal;
            _mapper = mapper;
            _examResultBusinessRules = examResultBusinessRules;
        }

        public async Task<CreatedExamResultResponse> AddAsync(CreateExamResultRequest createExamResultRequest)
        {
            ExamResult examResult = _mapper.Map<ExamResult>(createExamResultRequest);
            ExamResult addedExamResult = await _examResultDal.AddAsync(examResult);
            CreatedExamResultResponse createdExamResultResponse = _mapper.Map<CreatedExamResultResponse>(addedExamResult);
            return createdExamResultResponse;
        }

        public async Task<IPaginate<GetListExamResultResponse>> GetListAsync()
        {
            var examResult = await _examResultDal.GetListAsync();
            var mappedExamResults = _mapper.Map<Paginate<GetListExamResultResponse>>(examResult);
            return mappedExamResults;
        }

        public async Task<DeletedExamResultResponse> DeleteAsync(DeleteExamResultRequest deleteExamResultRequest)
        {
            await _examResultBusinessRules.IsExistsExamResult(deleteExamResultRequest.Id);
            ExamResult examResult = _mapper.Map<ExamResult>(deleteExamResultRequest);
            ExamResult deletedExamResult = await _examResultDal.DeleteAsync(examResult);
            DeletedExamResultResponse deletedExamResultResponse = _mapper.Map<DeletedExamResultResponse>(deletedExamResult);
            return deletedExamResultResponse;
        }

        public async Task<UpdatedExamResultResponse> UpdateAsync(UpdateExamResultRequest updateExamResultRequest)
        {
            await _examResultBusinessRules.IsExistsExamResult(updateExamResultRequest.Id);
            ExamResult examResult = _mapper.Map<ExamResult>(updateExamResultRequest);
            ExamResult updatedExamResult = await _examResultDal.UpdateAsync(examResult);
            UpdatedExamResultResponse updatedExamResultResponse = _mapper.Map<UpdatedExamResultResponse>(updatedExamResult);
            return updatedExamResultResponse;
        }

        public async Task<GetListExamResultResponse> GetByIdAsync(Guid id)
        {
            var examResult = await _examResultDal.GetListAsync(h => h.Id == id);
            return _mapper.Map<GetListExamResultResponse>(examResult.Items.FirstOrDefault());
        }
    }
}

