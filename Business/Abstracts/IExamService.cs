using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamService
{
    Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest);
    Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest);
    Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest);
    Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListExamResponse> GetByIdAsync(Guid id);
}
