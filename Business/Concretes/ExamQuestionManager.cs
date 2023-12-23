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

    public ExamQuestionManager(IExamQuestionDal examQuestionDal, IMapper mapper)
    {
        _examQuestionDal = examQuestionDal;
        _mapper = mapper;
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
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(deleteExamQuestionRequest);
        ExamQuestion deletedExamQuestion = await _examQuestionDal.DeleteAsync(examQuestion);
        DeletedExamQuestionResponse deletedExamQuestionResponse = _mapper.Map<DeletedExamQuestionResponse>(deletedExamQuestion);
        return deletedExamQuestionResponse;
    }

    public async Task<GetListExamQuestionResponse> GetByIdAsync(Guid id)
    {
        var examQuestion = await _examQuestionDal.GetListAsync(h => h.Id == id);
        return _mapper.Map<GetListExamQuestionResponse>(examQuestion.Items.FirstOrDefault());
    }

    public async Task<IPaginate<GetListExamQuestionResponse>> GetListAsync()
    {
        var examQuestions = await _examQuestionDal.GetListAsync();
        var mappedExamQuestions = _mapper.Map<Paginate<GetListExamQuestionResponse>>(examQuestions);
        return mappedExamQuestions;
    }

    public async Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest)
    {
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(updateExamQuestionRequest);
        ExamQuestion updatedExamQuestion = await _examQuestionDal.UpdateAsync(examQuestion);
        UpdatedExamQuestionResponse updatedExamQuestionResponse = _mapper.Map<UpdatedExamQuestionResponse>(updatedExamQuestion);
        return updatedExamQuestionResponse;
    }
}