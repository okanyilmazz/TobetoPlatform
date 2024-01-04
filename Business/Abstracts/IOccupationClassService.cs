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
    public interface IOccupationClassService
    {
        Task<CreatedOccupationClassResponse> AddAsync(CreateOccupationClassRequest createOccupationClassRequest);
        Task<UpdatedOccupationClassResponse> UpdateAsync(UpdateOccupationClassRequest updateOccupationClassRequest);
        Task<DeletedOccupationClassResponse> DeleteAsync(DeleteOccupationClassRequest deleteOccupationClassRequest);
        Task<IPaginate<GetListOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListOccupationClassResponse> GetByIdAsync(Guid id);
    }
}