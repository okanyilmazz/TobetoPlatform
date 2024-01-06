using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    IUserDal _userDal;

    public UserBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task IsExistsUser(Guid userId)
    {
        var result = await _userDal.GetAsync(a => a.Id == userId, enableTracking: false);
        if (result == null)
        {
            throw new Exception(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsUserMail(string email)
    {
        var result = await _userDal.GetAsync(
            predicate: a => a.Email == email,
            enableTracking: false);
        if (result != null)
        {
            throw new Exception(BusinessMessages.DataAvailable);
        }
    }
}