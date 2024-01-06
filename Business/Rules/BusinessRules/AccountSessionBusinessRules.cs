using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules;

public class AccountSessionBusinessRules : BaseBusinessRules
{
    private readonly IAccountSessionDal _accountSessionDal;

    public AccountSessionBusinessRules(IAccountSessionDal accountSessionDal)
    {
        _accountSessionDal = accountSessionDal;
    }

    public async Task IsExistsAccountSession(Guid accountSessionId)
    {
        var result = await _accountSessionDal.GetAsync(
            predicate: a => a.Id == accountSessionId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}