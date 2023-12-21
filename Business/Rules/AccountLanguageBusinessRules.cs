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
    public class AccountLanguageBusinessRules : BaseBusinessRules
    {
        IAccountLanguageDal _accountLanguageDal;

        public AccountLanguageBusinessRules(IAccountLanguageDal accountLanguageDal)
        {
            _accountLanguageDal = accountLanguageDal;
        }

        public async Task IsExistsAccountLanguage(Guid accountLanguageId)
        {
            var result = await _accountLanguageDal.GetListAsync(a => a.Id == accountLanguageId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
