using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramOccupationClassService
{
    Task<CreatedEducationProgramOccupationClassResponse> AddAsync(CreateEducationProgramOccupationClassRequest createEducationProgramOccupationClassRequest);
    Task<UpdatedEducationProgramOccupationClassResponse> UpdateAsync(UpdateEducationProgramOccupationClassRequest updateEducationProgramOccupationClassRequest);
    Task<DeletedEducationProgramOccupationClassResponse> DeleteAsync(DeleteEducationProgramOccupationClassRequest deleteEducationProgramOccupationClassRequest);
    Task<IPaginate<GetListEducationProgramOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListEducationProgramOccupationClassResponse> GetByIdAsync(Guid id);
}
