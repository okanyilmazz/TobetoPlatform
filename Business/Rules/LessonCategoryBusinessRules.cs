using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{
	public class LessonCategoryBusinessRules:BaseBusinessRules
	{

        ILessonCategoryDal _lessonCategoryDal;

        public LessonCategoryBusinessRules(ILessonCategoryDal lessonCategoryDal)
        {
            _lessonCategoryDal = lessonCategoryDal;
        }

        public async Task IsExistsLessonCategory(Guid lessonCategoryId)
        {
            var result = await _lessonCategoryDal.GetListAsync(l => l.Id == lessonCategoryId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

