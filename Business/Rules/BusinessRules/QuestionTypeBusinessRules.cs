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
    public class QuestionTypeBusinessRules : BaseBusinessRules
    {
        private readonly IQuestionTypeDal _questionTypeDal;

        public QuestionTypeBusinessRules(IQuestionTypeDal questionTypeDal)
        {
            _questionTypeDal = questionTypeDal;
        }

        public async Task IsExistsQuestionType(Guid questionTypeId)
        {
            var result = await _questionTypeDal.GetListAsync(
                predicate: q => q.Id == questionTypeId);

            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

