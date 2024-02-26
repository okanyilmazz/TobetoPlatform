using Business.Dtos.Requests.ModuleRequests;
using Business.Dtos.Responses.ModuleResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IModuleService
{
    Task<CreatedModuleResponse> AddAsync(CreateModuleRequest createModuleRequest);
    Task<UpdatedModuleResponse> UpdateAsync(UpdateModuleRequest updateModuleRequest);
    Task<DeletedModuleResponse> DeleteAsync(DeleteModuleRequest deleteModuleRequest);
    Task<IPaginate<GetListModuleResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListModuleResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListModuleResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
}
