using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
	public interface ILessonSubjectService
	{
        Task<CreatedLessonSubjectResponse> AddAsync(CreateLessonSubjectRequest createLessonSubjectRequest);
        Task<DeletedLessonSubjectResponse> DeleteAsync(DeleteLessonSubjectRequest deleteLessonSubjectRequest);
        Task<UpdatedLessonSubjectResponse> UpdateAsync(UpdateLessonSubjectRequest updateLessonSubjectRequest);
        Task<IPaginate<GetListLessonSubjectResponse>> GetListAsync();
        Task<GetListLessonSubjectResponse> GetByIdAsync(Guid id);
    }
}

