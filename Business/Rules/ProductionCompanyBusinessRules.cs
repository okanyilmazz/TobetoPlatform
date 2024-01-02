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
    public class ProductionCompanyBusinessRules : BaseBusinessRules
    {
        IProductionCompanyDal _productionCompanyDal;

        public ProductionCompanyBusinessRules(IProductionCompanyDal productionCompanyDal)
        {
            _productionCompanyDal = productionCompanyDal;
        }

        public async Task IsExistsProductionCompany(Guid productionCompanyId)
        {
            var result = await _productionCompanyDal.GetListAsync(p => p.Id == productionCompanyId, enableTracking: false);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
