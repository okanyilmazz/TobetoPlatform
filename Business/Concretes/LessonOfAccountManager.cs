using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AccountLessonManager : IAccountLessonService

    {
        IAccountLessonDal _instructorOfCourseDal;
        IMapper _mapper;

        public AccountLessonManager(IAccountLessonDal instructorOfCourseDal, IMapper mapper)
        {
            _instructorOfCourseDal = instructorOfCourseDal;
            _mapper = mapper;
        }

        public async Task<CreatedAccountLessonResponse> AddAsync(CreateAccountLessonRequest createInstructorOfCourseRequest)
        {
            AccountLesson instructorOfCourse = _mapper.Map<AccountLesson>(createInstructorOfCourseRequest);
            AccountLesson createdInstructorOfCourse = await _instructorOfCourseDal.AddAsync(instructorOfCourse);
            CreatedAccountLessonResponse createdInstructorOfCourseResponse = _mapper.Map<CreatedAccountLessonResponse>(createdInstructorOfCourse);
            return createdInstructorOfCourseResponse;
        }

        public async Task<DeletedAccountLessonResponse> DeleteAsync(DeleteAccountLessonRequest deleteInstructorOfCourseRequest)
        {
            AccountLesson instructorOfCourse = _mapper.Map<AccountLesson>(deleteInstructorOfCourseRequest);
            AccountLesson deletedInstructorOfCourse = await _instructorOfCourseDal.DeleteAsync(instructorOfCourse, true);
            DeletedAccountLessonResponse deletedInstructorOfCourseResponse = _mapper.Map<DeletedAccountLessonResponse>(deletedInstructorOfCourse);
            return deletedInstructorOfCourseResponse;
        }

        public async Task<IPaginate<GetListAccountLessonResponse>> GetListAsync()
        {
            var instructorOfCourses = await _instructorOfCourseDal.GetListAsync();
            var mappedInsructorOfCourses = _mapper.Map<Paginate<GetListAccountLessonResponse>>(instructorOfCourses);
            return mappedInsructorOfCourses;
        }

        public async Task<UpdatedAccountLessonResponse> UpdateAsync(UpdateAccountLessonRequest updateInstructorOfCourseRequest)
        {
            AccountLesson instructorOfCourse = _mapper.Map<AccountLesson>(updateInstructorOfCourseRequest);
            AccountLesson updatedInstructorOfCourse = await _instructorOfCourseDal.UpdateAsync(instructorOfCourse);
            UpdatedAccountLessonResponse updatedInstructorOfCourseResponse = _mapper.Map<UpdatedAccountLessonResponse>(updatedInstructorOfCourse);
            return updatedInstructorOfCourseResponse;
        }
    }
}
