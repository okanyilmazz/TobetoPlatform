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
    public class LessonModuleBusinessRules : BaseBusinessRules
    {
        ILessonModuleDal _lessonModuleDal;

        public LessonModuleBusinessRules(ILessonModuleDal lessonModuleDal)
        {
            _lessonModuleDal = lessonModuleDal;
        }


        public async Task IsExistsLessonModule(Guid lessonModuleId)
        {
            var result = await _lessonModuleDal.GetAsync(predicate: l => l.Id == lessonModuleId, enableTracking: false);

            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }

        }

    }
}
