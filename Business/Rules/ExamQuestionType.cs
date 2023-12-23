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
    public class ExamQuestionType : BaseBusinessRules
    {
        IExamQuestionTypeDal _examQuestionTypeDal;

        public ExamQuestionType(IExamQuestionTypeDal examQuestionTypeDal)
        {
            _examQuestionTypeDal = examQuestionTypeDal;
        }

        public async Task IsExistsExamQuestionType(Guid examQuestionTypeId)
        {
            var result = await _examQuestionTypeDal.GetListAsync(e => e.Id == examQuestionTypeId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

    }
}
