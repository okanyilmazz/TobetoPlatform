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
    public class AddressBusinessRules : BaseBusinessRules
    {
        private readonly IAddressDal _addressDal;

        public AddressBusinessRules(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public async Task IsExistsAddress(Guid addressId)
        {
            var result = await _addressDal.GetListAsync(a => a.Id == addressId);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }

        }
    }
}
