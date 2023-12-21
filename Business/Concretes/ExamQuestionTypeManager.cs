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
using Entities.Concretes;
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

        public ExamQuestionTypeManager(IExamQuestionTypeDal examQuestionTypeDal, IMapper mapper)
        {
            _examQuestionTypeDal = examQuestionTypeDal;
            _mapper = mapper;
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
            ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(deleteExamQuestionTypeRequest);
            ExamQuestionType deletedExamQuestionType = await _examQuestionTypeDal.DeleteAsync(examQuestionType);
            DeletedExamQuestionTypeResponse deletedExamQuestionTypeResponse = _mapper.Map<DeletedExamQuestionTypeResponse>(deletedExamQuestionType);
            return deletedExamQuestionTypeResponse;
        }

        public async Task<IPaginate<GetListExamQuestionTypeResponse>> GetListAsync()
        {
            var examQuestionType = await _examQuestionTypeDal.GetListAsync();
            var mappedExamQuestionType = _mapper.Map<Paginate<GetListExamQuestionTypeResponse>>(examQuestionType);
            return mappedExamQuestionType;
        }

        public async Task<UpdatedExamQuestionTypeResponse> UpdateAsync(UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest)
        {
            ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(updateExamQuestionTypeRequest);
            ExamQuestionType updatedExamQuestionType = await _examQuestionTypeDal.UpdateAsync(examQuestionType);
            UpdatedExamQuestionTypeResponse updatedExamQuestionTypeResponse = _mapper.Map<UpdatedExamQuestionTypeResponse>(updatedExamQuestionType);
            return updatedExamQuestionTypeResponse;
        }
    }
}
