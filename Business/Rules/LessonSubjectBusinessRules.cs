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
    public class LessonSubjectBusinessRules : BaseBusinessRules
    {
        private readonly ILessonSubjectDal _lessonSubjectDal;

        public LessonSubjectBusinessRules(ILessonSubjectDal lessonSubjectDal)
        {
            _lessonSubjectDal = lessonSubjectDal;
        }
        public async Task IsExistsLessonSubject(Guid lessonSubjectId)
        {
            var result = await _lessonSubjectDal.GetListAsync(
                predicate: l => l.Id == lessonSubjectId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
