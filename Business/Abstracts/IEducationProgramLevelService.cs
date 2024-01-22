using Business.Dtos.Requests.EducationProgramLevelRequests;
using Business.Dtos.Responses.EducationProgramLevelResponses;
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
