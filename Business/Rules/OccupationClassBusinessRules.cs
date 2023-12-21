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
            var result = await _occupationClassDal.GetListAsync(a => a.Id == occupationClassId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
