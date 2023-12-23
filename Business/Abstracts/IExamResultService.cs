using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IExamResultService
    {
        Task<IPaginate<GetListExamResultResponse>> GetListAsync();
        Task<CreatedExamResultResponse> AddAsync(CreateExamResultRequest createExamResultRequest);
        Task<UpdatedExamResultResponse> UpdateAsync(UpdateExamResultRequest updateExamResultRequest);
        Task<DeletedExamResultResponse> DeleteAsync(DeleteExamResultRequest deleteExamResultRequest);
        Task<GetListExamResultResponse> GetByIdAsync(Guid id);




    }
}

