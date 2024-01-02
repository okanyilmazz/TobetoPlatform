using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AccountUniversityBusinessRules : BaseBusinessRules
    {
        private readonly IAccountUniversityDal _accountUniversityDal;

        public AccountUniversityBusinessRules(IAccountUniversityDal accountUniversityDal)
        {
            _accountUniversityDal = accountUniversityDal;
        }
        public async Task IsExistsAccountUniversity(Guid accountUniversityId)
        {
            var result = await _accountUniversityDal.GetListAsync(
                predicate: a => a.Id == accountUniversityId,enableTracking:false);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
