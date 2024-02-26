using Business.Dtos.Requests.EducationProgramModuleRequests;
using Business.Dtos.Responses.EducationProgramModuleResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramModuleService
{
    Task<CreatedEducationProgramModuleResponse> AddAsync(CreateEducationProgramModuleRequest createEducationProgramModuleRequest);
    Task<UpdatedEducationProgramModuleResponse> UpdateAsync(UpdateEducationProgramModuleRequest updateEducationProgramModuleRequest);
    Task<DeletedEducationProgramModuleResponse> DeleteAsync(DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest);
    Task<IPaginate<GetListEducationProgramModuleResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListEducationProgramModuleResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListEducationProgramModuleResponse>> GetByModuleIdAsync(Guid moduleId);
    Task<IPaginate<GetListEducationProgramModuleResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
    Task<DeletedEducationProgramModuleResponse> DeleteByModuleIdAndEducationProgramIdAsync(DeleteEducationProgramModuleRequest deleteEducationProgramModuleRequest);
}
