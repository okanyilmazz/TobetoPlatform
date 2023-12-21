using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Helpers;
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
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        IExamQuestionTypeService _examQuestionType;
        IMapper _mapper;

        public ExamManager(IExamDal examDal, IMapper mapper, IExamQuestionTypeService examQuestionType)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examQuestionType = examQuestionType;
        }
        public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            Exam addedExam = await _examDal.AddAsync(exam);

            CreateExamQuestionTypeRequest createExamQuestionRequest =
                ExamQuestionTypeMapper.MapToCreateExamQuestionRequest(createExamRequest.QuestionTypeId, addedExam.Id);
            await _examQuestionType.AddAsync(createExamQuestionRequest);
            CreatedExamResponse createdExamResponse = _mapper.Map<CreatedExamResponse>(addedExam);
            return createdExamResponse;
        }

        public async Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(deleteExamRequest);
            Exam deletedExam = await _examDal.DeleteAsync(exam);
            DeletedExamResponse deletedExamResponse = _mapper.Map<DeletedExamResponse>(deletedExam);
            return deletedExamResponse;
        }

        public async Task<GetListExamResponse> GetByIdAsync(Guid id)
        {
            var exams = await _examDal.GetAsync(e => e.Id == id);
            var mappedExams = _mapper.Map<GetListExamResponse>(exams);
            return mappedExams;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync()
        {
            var exams = await _examDal.GetListAsync();
            var mappedExams = _mapper.Map<Paginate<GetListExamResponse>>(exams);
            return mappedExams;
        }

        public async Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(updateExamRequest);
            Exam updatedExam = await _examDal.UpdateAsync(exam);
            UpdatedExamResponse updatedExamResponse = _mapper.Map<UpdatedExamResponse>(updatedExam);
            return updatedExamResponse;
        }
    }
}