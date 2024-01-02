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
    public class DistrictBusinessRules : BaseBusinessRules
    {
        private readonly IDistrictDal _districtDal;

        public DistrictBusinessRules(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public async Task IsExistsDistrict(Guid districtId)
        {
            var result = await _districtDal.GetAsync(
                predicate: d => d.Id == districtId, enableTracking: false
                );
            if (result==null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}