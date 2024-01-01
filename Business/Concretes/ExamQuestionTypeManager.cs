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
    public class ExamQuestionTypeManager : IExamQuestionTypeService
    {
        IExamQuestionTypeDal _examQuestionTypeDal;
        IMapper _mapper;
        ExamQuestionTypeBusinessRules _examQuestionTypeBusinessRules;

        public ExamQuestionTypeManager(IExamQuestionTypeDal examQuestionTypeDal, IMapper mapper, ExamQuestionTypeBusinessRules examQuestionTypeBusinessRules)
        {
            _examQuestionTypeDal = examQuestionTypeDal;
            _mapper = mapper;
            _examQuestionTypeBusinessRules = examQuestionTypeBusinessRules;
        }

        public async Task<CreatedExamQuestionTypeResponse> AddAsync(CreateExamQuestionTypeRequest createExamQuestionTypeRequest)
        {
            ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(createExamQuestionTypeRequest);
            ExamQuestionType addedExamQuestionType = await _examQuestionTypeDal.AddAsync(examQuestionType);
            CreatedExamQuestionTypeResponse createdExamQuestionTypeResponse = _mapper.Map<CreatedExamQuestionTypeResponse>(addedExamQuestionType);
            return createdExamQuestionTypeResponse;
        }

        public async Task<DeletedExamQuestionTypeResponse> DeleteAsync(DeleteExamQuestionTypeRequest deleteExamQuestionTypeRequest)
        {
            await _examQuestionTypeBusinessRules.IsExistsExamQuestionType(deleteExamQuestionTypeRequest.Id);
            ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(deleteExamQuestionTypeRequest);
            ExamQuestionType deletedExamQuestionType = await _examQuestionTypeDal.DeleteAsync(examQuestionType);
            DeletedExamQuestionTypeResponse deletedExamQuestionTypeResponse = _mapper.Map<DeletedExamQuestionTypeResponse>(deletedExamQuestionType);
            return deletedExamQuestionTypeResponse;
        }

        public async Task<GetListExamQuestionTypeResponse> GetByIdAsync(Guid id)
        {
            var examQuestionType = await _examQuestionTypeDal.GetAsync(
                predicate: eqt => eqt.Id == id,
                include: eqt => eqt
                .Include(eqt => eqt.QuestionType)
                .Include(eqt => eqt.Exam));
            return _mapper.Map<GetListExamQuestionTypeResponse>(examQuestionType);
        }

        public async Task<IPaginate<GetListExamQuestionTypeResponse>> GetListAsync()
        {
            var examQuestionType = await _examQuestionTypeDal.GetListAsync(
                include: eqt => eqt
                .Include(eqt => eqt.QuestionType)
                .Include(eqt => eqt.Exam));
            var mappedExamQuestionType = _mapper.Map<Paginate<GetListExamQuestionTypeResponse>>(examQuestionType);
            return mappedExamQuestionType;
        }

        public async Task<UpdatedExamQuestionTypeResponse> UpdateAsync(UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest)
        {
            await _examQuestionTypeBusinessRules.IsExistsExamQuestionType(updateExamQuestionTypeRequest.Id);
            ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(updateExamQuestionTypeRequest);
            ExamQuestionType updatedExamQuestionType = await _examQuestionTypeDal.UpdateAsync(examQuestionType);
            UpdatedExamQuestionTypeResponse updatedExamQuestionTypeResponse = _mapper.Map<UpdatedExamQuestionTypeResponse>(updatedExamQuestionType);
            return updatedExamQuestionTypeResponse;
        }
    }
}
