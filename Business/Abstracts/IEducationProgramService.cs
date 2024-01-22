using Business.Dtos.Requests.EducationProgramRequests;
using Business.Dtos.Responses.EducationProgramResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEducationProgramService
    {
        Task<CreatedEducationProgramResponse> AddAsync(CreateEducationProgramRequest createEducationProgramRequest);
        Task<UpdatedEducationProgramResponse> UpdateAsync(UpdateEducationProgramRequest updateEducationProgramRequest);
        Task<DeletedEducationProgramResponse> DeleteAsync(DeleteEducationProgramRequest deleteEducationProgramRequest);
        Task<IPaginate<GetListEducationProgramResponse>> GetListAsync(PageRequest pageRequest);
        Task<IPaginate<GetListEducationProgramResponse>> GetByOccupationClassIdAsync(Guid occupationClassId);

    }
}
