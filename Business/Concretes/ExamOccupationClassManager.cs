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
    public class ExamOccupationClassManager : IExamOccupationClassService
    {
        IExamOccupationClassDal _examOccupationClassDal;
        IMapper _mapper;

        public ExamOccupationClassManager(IExamOccupationClassDal examOccupationClassDal, IMapper mapper)
        {
            _examOccupationClassDal = examOccupationClassDal;
            _mapper = mapper;
        }

        public async Task<CreatedExamOccupationClassResponse> AddAsync(CreateExamOccupationClassRequest createExamOccupationClassRequest)
        {
            ExamOccupationClass examOccupationClass = _mapper.Map<ExamOccupationClass>(createExamOccupationClassRequest);
            ExamOccupationClass createdExamOccupationClass = await _examOccupationClassDal.AddAsync(examOccupationClass);
            CreatedExamOccupationClassResponse createdExamOccupationClassResponse = _mapper.Map<CreatedExamOccupationClassResponse>(createdExamOccupationClass);
            return createdExamOccupationClassResponse;
        }

        public async Task<DeletedExamOccupationClassResponse> DeleteAsync(DeleteExamOccupationClassRequest deleteExamOccupationClassRequest)
        {
            ExamOccupationClass examOccupationClass = _mapper.Map<ExamOccupationClass>(deleteExamOccupationClassRequest);
            ExamOccupationClass deletedExamOccupationClass = await _examOccupationClassDal.DeleteAsync(examOccupationClass);
            DeletedExamOccupationClassResponse deletedExamOccupationClassResponse = _mapper.Map<DeletedExamOccupationClassResponse>(deletedExamOccupationClass);
            return deletedExamOccupationClassResponse;
        }

        public async Task<IPaginate<GetListExamOccupationClassResponse>> GetListAsync()
        {
            var examOccupationClasses = await _examOccupationClassDal.GetListAsync();
            var mappedExamOccupationClasses = _mapper.Map<Paginate<GetListExamOccupationClassResponse>>(examOccupationClasses);
            return mappedExamOccupationClasses;
        }

        public async Task<UpdatedExamOccupationClassResponse> UpdateAsync(UpdateExamOccupationClassRequest updateExamOccupationClassRequest)
        {
            ExamOccupationClass examOccupationClass = _mapper.Map<ExamOccupationClass>(updateExamOccupationClassRequest);
            ExamOccupationClass updatedExamOccupationClass = await _examOccupationClassDal.UpdateAsync(examOccupationClass);
            UpdatedExamOccupationClassResponse updatedExamOccupationClassResponse = _mapper.Map<UpdatedExamOccupationClassResponse>(updatedExamOccupationClass);
            return updatedExamOccupationClassResponse;
        }
    }
}
