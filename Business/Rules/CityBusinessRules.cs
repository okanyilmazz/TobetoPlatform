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
    public class CityBusinessRules:BaseBusinessRules
    {
        private readonly ICityDal _cityDal;

        public CityBusinessRules(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task IsExistsCity (Guid cityId) 
        {
         var result = await _cityDal.GetListAsync(c=>c.Id == cityId);   

            if(result.Count==0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
