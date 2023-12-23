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
    public interface ILessonService
    {
        Task<CreatedLessonResponse> AddAsync(CreateLessonRequest createLessonRequest);
        Task<DeletedLessonResponse> DeleteAsync(DeleteLessonRequest deleteLessonRequest);
        Task<UpdatedLessonResponse> UpdateAsync(UpdateLessonRequest updateLessonRequest);
        Task<IPaginate<GetListLessonResponse>> GetListAsync();
        Task<GetListLessonResponse> GetByIdAsync(Guid id);
        Task<IPaginate<GetListLessonResponse>> GetByAccountIdAsync(Guid id);
        Task<IPaginate<GetListLessonResponse>> GetByEducationProgramIdAsync(Guid id);
    }
}
