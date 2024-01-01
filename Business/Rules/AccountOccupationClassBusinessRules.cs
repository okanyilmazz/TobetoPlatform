using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class AccountOccupationClassBusinessRules : BaseBusinessRules
    {
        IAccountOccupationClassDal _accountOccupationClassDal;

        public AccountOccupationClassBusinessRules(IAccountOccupationClassDal accountOccupationClassDal)
        {
            _accountOccupationClassDal = accountOccupationClassDal;
        }

        public async Task IsExistsAccountOccupationClass(Guid accountOccupationClassId)
        {
            var result = await _accountOccupationClassDal.GetListAsync(a => a.Id == accountOccupationClassId,enableTracking:false);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
