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
    public class ExamQuestionBusinessRules : BaseBusinessRules
    {
        IExamQuestionDal _examQuestionDal;

        public ExamQuestionBusinessRules(IExamQuestionDal examQuestionDal)
        {
            _examQuestionDal = examQuestionDal;
        }


        public async Task IsExistsExamQuestion(Guid examQuestionId)
        {
            var result = await _examQuestionDal.GetListAsync(h => h.Id == examQuestionId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
