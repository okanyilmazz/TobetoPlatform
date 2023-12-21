using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
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
            LessonSubject lessonSubject = _mapper.Map<LessonSubject>(createLessonSubjectRequest);
            LessonSubject addedLessonSubject = await _lessonSubjectDal.AddAsync(lessonSubject);
            var mappedLessonSubject = _mapper.Map<CreatedLessonSubjectResponse>(addedLessonSubject);
            return mappedLessonSubject;
        }

        public async Task<DeletedLessonSubjectResponse> DeleteAsync(DeleteLessonSubjectRequest deleteLessonSubjectRequest)
        {
            await _lessonSubjectBusinessRules.IsExistsLessonSubject(deleteLessonSubjectRequest.Id);
            LessonSubject lessonSubject = _mapper.Map<LessonSubject>(deleteLessonSubjectRequest);
            LessonSubject deletedLessonSubject = await _lessonSubjectDal.DeleteAsync(lessonSubject);
            var mappedLessonSubject = _mapper.Map<DeletedLessonSubjectResponse>(deletedLessonSubject);
            return mappedLessonSubject;
        }

        public async Task<IPaginate<GetListLessonSubjectResponse>> GetListAsync()
        {
            var lessonSubjectList = await _lessonSubjectDal.GetListAsync();
            var mappedLessonSubject = _mapper.Map<Paginate<GetListLessonSubjectResponse>>(lessonSubjectList);
            return mappedLessonSubject;
        }

        public async Task<UpdatedLessonSubjectResponse> UpdateAsync(UpdateLessonSubjectRequest updateLessonSubjectRequest)
        {
            await _lessonSubjectBusinessRules.IsExistsLessonSubject(updateLessonSubjectRequest.Id);
            LessonSubject lessonSubject = _mapper.Map<LessonSubject>(updateLessonSubjectRequest);
            LessonSubject updatedLessonSubject = await _lessonSubjectDal.UpdateAsync(lessonSubject);
            var mappedLessonSubject = _mapper.Map<UpdatedLessonSubjectResponse>(updatedLessonSubject);
            return mappedLessonSubject;
        }
    }
}
