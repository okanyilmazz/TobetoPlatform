using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class LessonBusinessRules : BaseBusinessRules
    {
        ILessonDal _lessonDal;

        public LessonBusinessRules(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public async Task IsExistsLesson(Guid lessonId)
        {
            var result = await _lessonDal.GetListAsync(l => l.Id == lessonId, enableTracking: false);
            if (result.Items.Count != 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
