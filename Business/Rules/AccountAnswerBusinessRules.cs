using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AccountAnswerBusinessRules:BaseBusinessRules
    {
        private readonly IAccountAnswerDal _accountAnswerDal;

        public AccountAnswerBusinessRules(IAccountAnswerDal accountAnswerDal)
        {
            _accountAnswerDal = accountAnswerDal;
        }

        public async Task IsExistsAccountAnswer(Guid accountAnswerId)
        {
            var result = await _accountAnswerDal.GetListAsync(
                predicate: a => a.Id == accountAnswerId
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}