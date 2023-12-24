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
    public class UserBusinessRules : BaseBusinessRules
    {
        IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task IsExistsUser(Guid userId)
        {
            var result = await _userDal.GetListAsync(a => a.Id == userId);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

        public async Task IsExistsUserMail(string email)
        {
            var result = await _userDal.GetListAsync(a => a.Email == email);
            if (result.Items.Count != 0)
            {
                throw new Exception(BusinessMessages.DataAvailable);
            }
        }
    }
}