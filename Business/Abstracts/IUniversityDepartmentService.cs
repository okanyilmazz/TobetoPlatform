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
    public interface IUniversityDepartmentService
    {
        Task<IPaginate<GetListUniversityDepartmentResponse>> GetListAsync();
        Task<CreatedUniversityDepartmentResponse> AddAsync(CreateUniversityDepartmentRequest createUniversityDepartmentRequest);
        Task<UpdatedUniversityDepartmentResponse> UpdateAsync(UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest);
        Task<DeletedUniversityDepartmentResponse> DeleteAsync(DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest);
    }
}
