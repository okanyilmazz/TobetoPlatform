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
    public class AddressBusinessRules : BaseBusinessRules
    {
        private readonly IAddressDal _addressDal;

        public AddressBusinessRules(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public async Task IsExistsAdress(Guid addressId)
        {
            var result = await _addressDal.GetAsync(
                predicate: q => q.Id == addressId, enableTracking: false
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
