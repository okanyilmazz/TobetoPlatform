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
    public class ExamResultBusinessRules : BaseBusinessRules
    {
        IExamResultDal _examResultDal;

        public ExamResultBusinessRules(IExamResultDal examResultDal)
        {
            _examResultDal = examResultDal;
        }

        public async Task IsExistsExamResult(Guid examResultId)
        {
            var result = await _examResultDal.GetListAsync(e => e.Id == examResultId, enableTracking: false);
            if(result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
