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

namespace Business.Concretes
{
    public class EducationProgramLessonManager : IEducationProgramLessonService
    {
        IEducationProgramLessonDal _educationProgramLessonDal;
        IMapper _mapper;
        EducationProgramLessonBusinessRules _educationProgramLessonBusinessRules;

        public EducationProgramLessonManager(IEducationProgramLessonDal educationProgramLessonDal, IMapper mapper, EducationProgramLessonBusinessRules educationProgramLessonBusinessRules)
        {
            _educationProgramLessonDal = educationProgramLessonDal;
            _mapper = mapper;
            _educationProgramLessonBusinessRules = educationProgramLessonBusinessRules;
        }

        public async Task<CreatedEducationProgramLessonResponse> AddAsync(CreateEducationProgramLessonRequest createEducationProgramLessonRequest)
        {
            EducationProgramLesson educationProgramLesson = _mapper.Map<EducationProgramLesson>(createEducationProgramLessonRequest);
            EducationProgramLesson addedEducationProgramLesson = await _educationProgramLessonDal.AddAsync(educationProgramLesson);
            CreatedEducationProgramLessonResponse createdEducationProgramLessonResponse = _mapper.Map<CreatedEducationProgramLessonResponse>(addedEducationProgramLesson);
            return createdEducationProgramLessonResponse;
        }

        public async Task<DeletedEducationProgramLessonResponse> DeleteAsync(DeleteEducationProgramLessonRequest deleteEducationProgramLessonRequest)
        {
            await _educationProgramLessonBusinessRules.IsExistsEducationProgramLesson(deleteEducationProgramLessonRequest.Id);
            EducationProgramLesson educationProgramLesson = _mapper.Map<EducationProgramLesson>(deleteEducationProgramLessonRequest);
            EducationProgramLesson deletedEducationProgramLesson = await _educationProgramLessonDal.DeleteAsync(educationProgramLesson);
            DeletedEducationProgramLessonResponse deletedEducationProgramLessonResponse = _mapper.Map<DeletedEducationProgramLessonResponse>(deletedEducationProgramLesson);
            return deletedEducationProgramLessonResponse;
        }

        public async Task<GetListEducationProgramLessonResponse> GetByIdAsync(Guid id)
        {
            var EducationProgramLesson = await _educationProgramLessonDal.GetListAsync(h => h.Id == id);
            return _mapper.Map<GetListEducationProgramLessonResponse>(EducationProgramLesson.Items.FirstOrDefault());
        }

        public async Task<IPaginate<GetListEducationProgramLessonResponse>> GetListAsync()
        {
            var EducationProgramLesson = await _educationProgramLessonDal.GetListAsync();
            var mappedEducationProgramLesson = _mapper.Map<Paginate<GetListEducationProgramLessonResponse>>(EducationProgramLesson);
            return mappedEducationProgramLesson;
        }

        public async Task<UpdatedEducationProgramLessonResponse> UpdateAsync(UpdateEducationProgramLessonRequest updateEducationProgramLessonRequest)
        {
            await _educationProgramLessonBusinessRules.IsExistsEducationProgramLesson(updateEducationProgramLessonRequest.Id);
            EducationProgramLesson educationProgramLesson = _mapper.Map<EducationProgramLesson>(updateEducationProgramLessonRequest);
            EducationProgramLesson updatedEducationProgramLesson = await _educationProgramLessonDal.UpdateAsync(educationProgramLesson);
            UpdatedEducationProgramLessonResponse updatedEducationProgramLessonResponse = _mapper.Map<UpdatedEducationProgramLessonResponse>(updatedEducationProgramLesson);
            return updatedEducationProgramLessonResponse;
        }
    }
}
