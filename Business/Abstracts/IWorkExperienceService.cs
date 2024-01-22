using Business.Dtos.Requests.WorkExperienceResquests;
using Business.Dtos.Responses.WorkExperienceResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IWorkExperienceService
    {
        Task<CreatedWorkExperienceResponse> AddAsync(CreateWorkExperienceRequest createWorkExperienceRequest);
        Task<DeletedWorkExperienceResponse> DeleteAsync(DeleteWorkExperienceRequest deleteWorkExperienceRequest);
        Task<UpdatedWorkExperienceResponse> UpdateAsync(UpdateWorkExperienceRequest updateWorkExperienceRequest);
        Task<IPaginate<GetListWorkExperienceResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListWorkExperienceResponse> GetByIdAsync(Guid id);
    }
}
