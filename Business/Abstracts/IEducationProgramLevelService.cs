using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEducationProgramLevelService
    {
        Task<CreatedEducationProgramLevelResponse> AddAsync(CreateEducationProgramLevelRequest createEducationProgramLevelRequest);
        Task<DeletedEducationProgramLevelResponse> DeleteAsync(DeleteEducationProgramLevelRequest deleteEducationProgramLevelRequest);
        Task<UpdatedEducationProgramLevelResponse> UpdateAsync(UpdateEducationProgramLevelRequest updateEducationProgramLevelRequest);
        Task<IPaginate<GetListEducationProgramLevelResponse>> GetListAsync();
    }
}
