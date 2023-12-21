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
            var result = await _accountDal.GetListAsync(a => a.Id == accountId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}