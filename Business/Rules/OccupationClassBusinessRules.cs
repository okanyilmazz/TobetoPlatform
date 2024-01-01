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
    public class OccupationClassBusinessRules : BaseBusinessRules
    {
        IOccupationClassDal _occupationClassDal;

        public OccupationClassBusinessRules(IOccupationClassDal occupationClassDal)
        {
            _occupationClassDal = occupationClassDal;
        }

        public async Task IsExistsOccupationClass(Guid occupationClassId)
        {
            var result = await _occupationClassDal.GetAsync(predicate: a => a.Id == occupationClassId, enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
