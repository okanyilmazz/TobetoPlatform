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

namespace Business.Concretes;

public class ExamQuestionManager : IExamQuestionService
{
    IExamQuestionDal _examQuestionDal;
    IMapper _mapper;
    ExamQuestionBusinessRules _examQuestionBusinessRules;

    public ExamQuestionManager(IExamQuestionDal examQuestionDal, IMapper mapper, ExamQuestionBusinessRules examQuestionBusinessRules)
    {
        _examQuestionDal = examQuestionDal;
        _mapper = mapper;
        _examQuestionBusinessRules = examQuestionBusinessRules;
    }

    public async Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest)
    {
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(createExamQuestionRequest);
        ExamQuestion addedExamQuestion = await _examQuestionDal.AddAsync(examQuestion);
        CreatedExamQuestionResponse createdExamQuestionResponse = _mapper.Map<CreatedExamQuestionResponse>(addedExamQuestion);
        return createdExamQuestionResponse;
    }

    public async Task<DeletedExamQuestionResponse> DeleteAsync(DeleteExamQuestionRequest deleteExamQuestionRequest)
    {
        await _examQuestionBusinessRules.IsExistsExamQuestion(deleteExamQuestionRequest.Id);
        ExamQuestion examQuestion = await _examQuestionDal.GetAsync(predicate: a => a.Id == deleteExamQuestionRequest.Id);
        ExamQuestion deletedExamQuestion = await _examQuestionDal.DeleteAsync(examQuestion, false);
        DeletedExamQuestionResponse createdExamQuestionResponse = _mapper.Map<DeletedExamQuestionResponse>(deletedExamQuestion);
        return createdExamQuestionResponse;

    }

    public async Task<GetListExamQuestionResponse> GetByIdAsync(Guid id)
    {
        var examQuestion = await _examQuestionDal.GetAsync(
             predicate: e => e.Id == id,
                include: eq => eq.
                Include(eq => eq.Exam)
                .Include(eq => eq.Question));
        var mappedExamQuestion = _mapper.Map<GetListExamQuestionResponse>(examQuestion);
        return mappedExamQuestion;
    }

    public async Task<IPaginate<GetListExamQuestionResponse>> GetListAsync()                     
    {
        var examQuestions = await _examQuestionDal.GetListAsync(
                include: eq => eq.
                Include(eq => eq.Exam)
                .Include(eq => eq.Question));
        var mappedExamQuestions = _mapper.Map<Paginate<GetListExamQuestionResponse>>(examQuestions);
        return mappedExamQuestions;
    }

    public async Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest)
    {
        await _examQuestionBusinessRules.IsExistsExamQuestion(updateExamQuestionRequest.Id);
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(updateExamQuestionRequest);
        ExamQuestion updatedExamQuestion = await _examQuestionDal.UpdateAsync(examQuestion);
        UpdatedExamQuestionResponse updatedExamQuestionResponse = _mapper.Map<UpdatedExamQuestionResponse>(updatedExamQuestion);
        return updatedExamQuestionResponse;
    }
}
//public async Task<GetListAccountOccupationClassResponse> GetByIdAsync(Guid id)
//{
//    var accountOccupationClassList = await _accountOccupationClassDal.GetAsync(
//        predicate: a => a.Id == id,
//        include: aoc => aoc.
//        Include(aoc => aoc.OccupationClass)
//        .Include(aoc => aoc.Account).ThenInclude(a => a.User));
//    var mappedAccountOccupationClass = _mapper.Map<GetListAccountOccupationClassResponse>(accountOccupationClassList);
//    return mappedAccountOccupationClass;
//}