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
    public class CountryBusinessRules :BaseBusinessRules
    {
        private readonly ICountryDal _countryDal;

        public CountryBusinessRules(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task IsExistsCountry(Guid countryId)
        {
            var result = await _countryDal.GetListAsync(
                predicate: c => c.Id == countryId
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
