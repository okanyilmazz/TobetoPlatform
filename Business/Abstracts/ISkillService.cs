using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISkillService
    {
        Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest);
        Task<DeletedSkillResponse> DeleteAsync(DeleteSkillRequest deleteSkillRequest);
        Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest);
        Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest);
        Task<IPaginate<GetListSkillResponse>> GetByAccountIdAsync(Guid id);
        Task<GetListSkillResponse> GetByIdAsync(Guid id);

    }
}
