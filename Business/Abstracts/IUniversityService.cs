using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Responses.UniversityResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUniversityService
    {
        Task<CreatedUniversityResponse> AddAsync(CreateUniversityRequest createUniversityRequest);
        Task<UpdatedUniversityResponse> UpdateAsync(UpdateUniversityRequest updateUniversityRequest);
        Task<DeletedUniversityResponse> DeleteAsync(DeleteUniversityRequest deleteUniversityRequest);
        Task<IPaginate<GetListUniversityResponse>> GetListAsync(PageRequest pageRequest);
    }
}
