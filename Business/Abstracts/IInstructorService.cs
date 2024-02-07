using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.BlogResponses;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest);
        Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);
    }
}
