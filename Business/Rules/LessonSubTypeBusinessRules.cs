using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class LessonSubTypeBusinessRules : BaseBusinessRules
    {

        private readonly ILessonSubTypeDal _lessonSubTypeDal;

        public LessonSubTypeBusinessRules(ILessonSubTypeDal lessonSubTypeDal)
        {
            _lessonSubTypeDal = lessonSubTypeDal;
        }

        public async Task IsExistsLessonSubType(Guid lessonSubTypeId)
        {
            var result = await _lessonSubTypeDal.GetAsync(
               predicate: l => l.Id == lessonSubTypeId, enableTracking: false
               );

            if (result==null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

    }
}
