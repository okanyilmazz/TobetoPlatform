using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LessonSubjectRequests;
using Business.Dtos.Responses.LessonSubjectResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class LessonSubjectManager : ILessonSubjectService
{
    ILessonSubjectDal _lessonSubjectDal;
    IMapper _mapper;
    LessonSubjectBusinessRules _lessonSubjectBusinessRules;

    public LessonSubjectManager(ILessonSubjectDal lessonSubjectDal, IMapper mapper, LessonSubjectBusinessRules lessonSubjectBusinessRules)
    {
        _lessonSubjectDal = lessonSubjectDal;
        _mapper = mapper;
        _lessonSubjectBusinessRules = lessonSubjectBusinessRules;
    }

    public async Task<CreatedLessonSubjectResponse> AddAsync(CreateLessonSubjectRequest createLessonSubjectRequest)
    {
        var lessonSubject = _mapper.Map<LessonSubject>(createLessonSubjectRequest);
        var addedLessonSubject = await _lessonSubjectDal.AddAsync(lessonSubject);
        var responseLessonSubject = _mapper.Map<CreatedLessonSubjectResponse>(addedLessonSubject);
        return responseLessonSubject;
    }

    public async Task<DeletedLessonSubjectResponse> DeleteAsync(DeleteLessonSubjectRequest deleteLessonSubjectRequest)
    {
        await _lessonSubjectBusinessRules.IsExistsLessonSubject(deleteLessonSubjectRequest.Id);
        var lessonSubject = _mapper.Map<LessonSubject>(deleteLessonSubjectRequest);
        var deletedLessonSubject = await _lessonSubjectDal.DeleteAsync(lessonSubject);
        var responseLessonSubject = _mapper.Map<DeletedLessonSubjectResponse>(deletedLessonSubject);
        return responseLessonSubject;
    }

    public async Task<GetListLessonSubjectResponse> GetByIdAsync(Guid id)
    {
        var lessonSubject = await _lessonSubjectDal.GetListAsync(l => l.Id == id);
        return _mapper.Map<GetListLessonSubjectResponse>(lessonSubject.Items.FirstOrDefault());
    }

    public async Task<IPaginate<GetListLessonSubjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var lessonSubjectListed = await _lessonSubjectDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedListed = _mapper.Map<Paginate<GetListLessonSubjectResponse>>(lessonSubjectListed);
        return mappedListed;
    }

    public async Task<UpdatedLessonSubjectResponse> UpdateAsync(UpdateLessonSubjectRequest updateLessonSubjectRequest)
    {
        await _lessonSubjectBusinessRules.IsExistsLessonSubject(updateLessonSubjectRequest.Id);
        var lessonSubject = _mapper.Map<LessonSubject>(updateLessonSubjectRequest);
        var updatedLessonSubject = await _lessonSubjectDal.UpdateAsync(lessonSubject);
        var responseLessonSubject = _mapper.Map<UpdatedLessonSubjectResponse>(updatedLessonSubject);
        return responseLessonSubject;
    }
}


   