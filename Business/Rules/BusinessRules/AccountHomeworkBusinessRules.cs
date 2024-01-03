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
    public class AccountHomeworkBusinessRules : BaseBusinessRules
    {
        private readonly IAccountHomeworkDal _accountHomeworkDal;

        public AccountHomeworkBusinessRules(IAccountHomeworkDal accountHomeworkDal)
        {
            _accountHomeworkDal = accountHomeworkDal;
        }

        public async Task IsExistsAccountHomework(Guid accountHomeworkId)
        {
            var result = await _accountHomeworkDal.GetAsync(
                predicate: a => a.Id == accountHomeworkId,
                enableTracking: false);

            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
