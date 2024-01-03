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
    public class HomeworkBusinessRules : BaseBusinessRules
    {
        IHomeworkDal _homeworkDal;

        public HomeworkBusinessRules(IHomeworkDal homeworkDal)
        {
            _homeworkDal = homeworkDal;
        }


        public async Task IsExistsHomework(Guid homeworkId)
        {
            var result = await _homeworkDal.GetListAsync(h => h.Id == homeworkId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
