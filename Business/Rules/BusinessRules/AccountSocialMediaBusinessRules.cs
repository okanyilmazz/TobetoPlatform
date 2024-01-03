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
    public class AccountSocialMediaBusinessRules : BaseBusinessRules
    {
        IAccountSocialMediaDal _accountSocialMediaDal;

        public AccountSocialMediaBusinessRules(IAccountSocialMediaDal accountSocialMediaDal)
        {
            _accountSocialMediaDal = accountSocialMediaDal;
        }

        public async Task IsExistsAccountSocialMedia(Guid accountSocialMediaId)
        {
            var result = await _accountSocialMediaDal.GetAsync(a => a.Id == accountSocialMediaId, enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
