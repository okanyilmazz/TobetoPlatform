using Business.Abstracts;
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
    public class AccountLessonBusinessRules : BaseBusinessRules
    {
        IAccountLessonDal _AccountLessonDal;

        public AccountLessonBusinessRules(IAccountLessonDal AccountLessonDal)
        {
            _AccountLessonDal = AccountLessonDal;
        }

        public async Task IsExistsAccountLesson(Guid AccountLessonId)
        {
            var result = await _AccountLessonDal.GetListAsync(a => a.Id == AccountLessonId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}