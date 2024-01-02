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
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        ExamBusinessRules _examBusinessRules;
        IMapper _mapper;

        public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }
        public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
        {
            var exam = _mapper.Map<Exam>(createExamRequest);
            var addedExam = await _examDal.AddAsync(exam);
            var responseExam = _mapper.Map<CreatedExamResponse>(addedExam);
            return responseExam;
        }

        public async Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest)
        {
            await _examBusinessRules.IsExistsExam(deleteExamRequest.Id);
            Exam exam = await _examDal.GetAsync(predicate: e => e.Id == deleteExamRequest.Id);
            Exam deletedExam = await _examDal.DeleteAsync(exam);
            DeletedExamResponse deletedExamResponse = _mapper.Map<DeletedExamResponse>(deletedExam);
            return deletedExamResponse;
        }

        public async Task<GetListExamResponse> GetByIdAsync(Guid id)
        {
            var exam = await _examDal.GetListAsync(h => h.Id == id);
            return _mapper.Map<GetListExamResponse>(exam.Items.FirstOrDefault());
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