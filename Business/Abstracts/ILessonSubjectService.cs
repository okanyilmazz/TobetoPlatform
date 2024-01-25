using System;
using Business.Dtos.Requests.LessonSubjectRequests;
using Business.Dtos.Responses.LessonSubjectResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ILessonSubjectService
	{
        Task<CreatedLessonSubjectResponse> AddAsync(CreateLessonSubjectRequest createLessonSubjectRequest);
        Task<DeletedLessonSubjectResponse> DeleteAsync(DeleteLessonSubjectRequest deleteLessonSubjectRequest);
        Task<UpdatedLessonSubjectResponse> UpdateAsync(UpdateLessonSubjectRequest updateLessonSubjectRequest);
        Task<IPaginate<GetListLessonSubjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListLessonSubjectResponse> GetByIdAsync(Guid id);
    }
}

