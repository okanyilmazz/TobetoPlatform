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
    public interface IQuestionTypeService
	{
        Task<IPaginate<GetListQuestionTypeResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedQuestionTypeResponse> AddAsync(CreateQuestionTypeRequest createQuestionTypeRequest);
        Task<UpdatedQuestionTypeResponse> UpdateAsync(UpdateQuestionTypeRequest updateQuestionTypeRequest);
        Task<DeletedQuestionTypeResponse> DeleteAsync(DeleteQuestionTypeRequest deleteQuestionTypeRequest);
    }
}

