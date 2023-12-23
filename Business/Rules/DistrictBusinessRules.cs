using Business.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class DistrictBusinessRules
    {
        private readonly IDistrictDal _districtDal;

        public DistrictBusinessRules(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public async Task IsExistsDistrict(Guid districtId)
        {
            var result = await _districtDal.GetListAsync(
                predicate: q => q.Id == districtId
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}