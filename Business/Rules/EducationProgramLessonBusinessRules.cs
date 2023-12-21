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
    public class EducationProgramLessonBusinessRules : BaseBusinessRules
    {
        IEducationProgramLessonDal _educationProgramLessonDal;

        public EducationProgramLessonBusinessRules(IEducationProgramLessonDal educationProgramLessonDal)
        {
            _educationProgramLessonDal = educationProgramLessonDal;
        }

        public async Task IsExistsEducationProgramLesson(Guid educationProgramLessonId)
        {
            var result = await _educationProgramLessonDal.GetListAsync(a => a.Id == educationProgramLessonId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
