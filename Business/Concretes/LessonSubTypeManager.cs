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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class LessonSubTypeManager : ILessonSubTypeService
    {

        ILessonSubTypeDal _lessonSubTypeDal;
        IMapper _mapper;
        LessonSubTypeBusinessRules _lessonSubTypeBusinessRules;

        public LessonSubTypeManager(ILessonSubTypeDal lessonSubTypeDal, IMapper mapper, LessonSubTypeBusinessRules lessonSubTypeBusinessRules)
        {
            _lessonSubTypeDal = lessonSubTypeDal;
            _mapper = mapper;
            _lessonSubTypeBusinessRules = lessonSubTypeBusinessRules;
        }

        public async Task<CreatedLessonSubTypeResponse> AddAsync(CreateLessonSubTypeRequest createLessonSubTypeRequest)
        {
            LessonSubType lessonSubType = _mapper.Map<LessonSubType>(createLessonSubTypeRequest);
            LessonSubType addedLessonSubType = await _lessonSubTypeDal.AddAsync(lessonSubType);
            var mappedLessonSubType = _mapper.Map<CreatedLessonSubTypeResponse>(addedLessonSubType);
            return mappedLessonSubType;
        }

        public async Task<DeletedLessonSubTypeResponse> DeleteAsync(DeleteLessonSubTypeRequest deleteLessonSubTypeRequest)
        {
            await _lessonSubTypeBusinessRules.IsExistsLessonSubType(deleteLessonSubTypeRequest.Id);
            LessonSubType lessonSubType = _mapper.Map<LessonSubType>(deleteLessonSubTypeRequest);
            LessonSubType deletedLessonSubType = await _lessonSubTypeDal.DeleteAsync(lessonSubType);
            var mappedLessonSubType = _mapper.Map<DeletedLessonSubTypeResponse>(deletedLessonSubType);
            return mappedLessonSubType;
        }

        public async Task<IPaginate<GetListLessonSubTypeResponse>> GetListAsync()
        {
            var lessonSubTypeList = await _lessonSubTypeDal.GetListAsync();
            var mappedLessonSubType = _mapper.Map<Paginate<GetListLessonSubTypeResponse>>(lessonSubTypeList);
            return mappedLessonSubType;
        }

        public async Task<UpdatedLessonSubTypeResponse> UpdateAsync(UpdateLessonSubTypeRequest updateLessonSubTypeRequest)
        {    await _lessonSubTypeBusinessRules.IsExistsLessonSubType(updateLessonSubTypeRequest.Id);
            LessonSubType lessonSubType = _mapper.Map<LessonSubType>(updateLessonSubTypeRequest);
            LessonSubType updateedLessonSubType = await _lessonSubTypeDal.UpdateAsync(lessonSubType);
            var mappedLessonSubType = _mapper.Map<UpdatedLessonSubTypeResponse>(updateedLessonSubType);
            return mappedLessonSubType;
        }
    }
}
