using Business.Abstracts;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AccountLessonBusinessRules : BaseBusinessRules
    {
        IAccountLessonDal _accountLessonDal;

        public AccountLessonBusinessRules(IAccountLessonDal AccountLessonDal)
        {
            _accountLessonDal = AccountLessonDal;
        }

        public async Task IsExistsAccountLesson(Guid accountLessonId)
        {
            var result = await _accountLessonDal.GetAsync(
                predicate: a => a.Id == accountLessonId, enableTracking: false
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}