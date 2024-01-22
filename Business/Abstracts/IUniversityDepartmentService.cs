using Business.Dtos.Requests.UniversityDepartmentRequests;
using Business.Dtos.Responses.UniversityDepartmentResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUniversityDepartmentService
    {
        Task<IPaginate<GetListUniversityDepartmentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUniversityDepartmentResponse> AddAsync(CreateUniversityDepartmentRequest createUniversityDepartmentRequest);
        Task<UpdatedUniversityDepartmentResponse> UpdateAsync(UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest);
        Task<DeletedUniversityDepartmentResponse> DeleteAsync(DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest);
    }
}
