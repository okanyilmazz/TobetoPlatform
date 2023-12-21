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
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        IMapper _mapper;
        LessonBusinessRules _lessonBusinessRules;

        public LessonManager(ILessonDal lessonDal, IMapper mapper, LessonBusinessRules lessonBusinessRules)
        {
            _lessonDal = lessonDal;
            _mapper = mapper;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<CreatedLessonResponse> AddAsync(CreateLessonRequest createLessonRequest)
        {
            Lesson lesson = _mapper.Map<Lesson>(createLessonRequest);
            Lesson addedLesson = await _lessonDal.AddAsync(lesson);
            CreatedLessonResponse createdLessonResponse = _mapper.Map<CreatedLessonResponse>(addedLesson);
            return createdLessonResponse;
        }

        public async Task<DeletedLessonResponse> DeleteAsync(DeleteLessonRequest deleteLessonRequest)
        {
            await _lessonBusinessRules.IsExistsLesson(deleteLessonRequest.Id);
            Lesson lesson = _mapper.Map<Lesson>(deleteLessonRequest);
            Lesson deletedLesson = await _lessonDal.DeleteAsync(lesson);
            DeletedLessonResponse deletedLessonResponse = _mapper.Map<DeletedLessonResponse>(deletedLesson);
            return deletedLessonResponse;
        }

        public async Task<IPaginate<GetListLessonResponse>> GetListAsync()
        {
            var lessons = await _lessonDal.GetListAsync();
            var mappedLessons = _mapper.Map<Paginate<GetListLessonResponse>>(lessons);
            return mappedLessons;
        }

        public async Task<GetListLessonResponse> GetByIdAsync(Guid id)
        {
            var lesson = await _lessonDal.GetAsync(l => l.Id == id);
            var mappedLesson = _mapper.Map<GetListLessonResponse>(lesson);
            return mappedLesson;
        }

        public async Task<UpdatedLessonResponse> UpdateAsync(UpdateLessonRequest updateLessonRequest)
        {
            await _lessonBusinessRules.IsExistsLesson(updateLessonRequest.Id);
            Lesson lesson = _mapper.Map<Lesson>(updateLessonRequest);
            Lesson updatedLesson = await _lessonDal.UpdateAsync(lesson);
            UpdatedLessonResponse updatedLessonResponse = _mapper.Map<UpdatedLessonResponse>(updatedLesson);
            return updatedLessonResponse;
        }

        public async Task<IPaginate<GetListLessonResponse>> GetByAccountIdAsync(Guid id)
        {
            var lessonList = await _lessonDal.GetListAsync(
               include: l => l.Include(a => a.Accounts));

            var filteredLessons = lessonList
                .Items.SelectMany(l => l.Accounts.Where(a => a.Id== id).Select(a => l)).ToList();
            var mappedLesson= _mapper.Map<Paginate<GetListLessonResponse>>(filteredLessons);
            return mappedLesson;
        }

    }
}
