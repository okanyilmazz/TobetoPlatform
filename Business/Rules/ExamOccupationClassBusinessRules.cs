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
    public class ExamOccupationClassBusinessRules : BaseBusinessRules
    {
        private readonly IExamOccupationClassDal _examOccupationClassDal;

        public ExamOccupationClassBusinessRules(IExamOccupationClassDal examOccupationClassDal)
        {
            _examOccupationClassDal = examOccupationClassDal;
        }

        public async Task IsExistsExamOccupationClass(Guid examOccupationClassId)
        {
            var result = await _examOccupationClassDal.GetAsync(
                predicate: e => e.Id == examOccupationClassId, enableTracking: false
                );
            if (result==null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
