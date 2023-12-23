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
            var result = await _lessonSubTypeDal.GetListAsync(
               predicate: l => l.Id == lessonSubTypeId
               );

            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

    }
}
