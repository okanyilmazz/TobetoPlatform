using Business.Dtos.Requests.CreateRequests;
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
    public class ExamBusinessRules : BaseBusinessRules
    {
        private readonly IExamDal _examDal;

        public ExamBusinessRules(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public async Task IsExistsExam(Guid examId)
        {
            var result = await _examDal.GetAsync(
                predicate: c => c.Id == examId, enableTracking: false
                );
            if (result==null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
