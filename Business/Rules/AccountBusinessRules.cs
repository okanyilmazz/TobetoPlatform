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
    public class AccountBusinessRules : BaseBusinessRules
    {
        IAccountDal _accountDal;

        public AccountBusinessRules(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public async Task IsExistsAccount(Guid accountId)
        {
            var result = await _accountDal.GetAsync(
                predicate: a => a.Id == accountId,
                enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

        public async Task IsExistsNationalId(string nationalId)
        {
            var result = await _accountDal.GetAsync(
                predicate: a => a.NationalId == nationalId,
                enableTracking: false);
            if (result != null)
            {
                throw new Exception(BusinessMessages.DataAvailable);
            }
        }
    }
}