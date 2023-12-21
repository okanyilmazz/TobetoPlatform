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
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class LessonCategoryManager : ILessonCategoryService
    {
        ILessonCategoryDal _lessonCategoryDal;
        IMapper _mapper;

        public LessonCategoryManager(ILessonCategoryDal lessonCategoryDal, IMapper mapper)
        {
            _lessonCategoryDal = lessonCategoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedLessonCategoryResponse> AddAsync(CreateLessonCategoryRequest createLessonCategoryRequest)
        {
            LessonCategory lessonCategory = _mapper.Map<LessonCategory>(createLessonCategoryRequest);
            LessonCategory addedLessonCategory = await _lessonCategoryDal.AddAsync(lessonCategory);
            var mappedLessonCategory = _mapper.Map<CreatedLessonCategoryResponse>(addedLessonCategory);
            return mappedLessonCategory;
        }

        public async Task<DeletedLessonCategoryResponse> DeleteAsync(DeleteLessonCategoryRequest deleteLessonCategoryRequest)
        {
            LessonCategory lessonCategory = _mapper.Map<LessonCategory>(deleteLessonCategoryRequest);
            LessonCategory deletedLessonCategory = await _lessonCategoryDal.DeleteAsync(lessonCategory);
            var mappedLessonCategory = _mapper.Map<DeletedLessonCategoryResponse>(deletedLessonCategory);
            return mappedLessonCategory;
        }

        public async Task<IPaginate<GetListLessonCategoryResponse>> GetListAsync()
        {
            var lessonCategoryList = await _lessonCategoryDal.GetListAsync();
            var mappedLessonCategory = _mapper.Map<Paginate<GetListLessonCategoryResponse>>(lessonCategoryList);
            return mappedLessonCategory;
        }

        public async Task<UpdatedLessonCategoryResponse> UpdateAsync(UpdateLessonCategoryRequest updateLessonCategoryRequest)
        {
            LessonCategory lessonCategory = _mapper.Map<LessonCategory>(updateLessonCategoryRequest);
            LessonCategory updateedLessonCategory = await _lessonCategoryDal.UpdateAsync(lessonCategory);
            var mappedLessonCategory = _mapper.Map<UpdatedLessonCategoryResponse>(updateedLessonCategory);
            return mappedLessonCategory;
        }
    }
}
