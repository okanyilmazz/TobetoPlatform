using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Rules;

public class SocialMediaBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaDal _socialMediaDal;

    public SocialMediaBusinessRules(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public async Task IsExistsSocialMedia(Guid socialMediaId)
    {

        var result = await _socialMediaDal.GetListAsync(s => s.Id == socialMediaId, enableTracking: false);

        if (result == null)
        {
            throw new Exception(BusinessMessages.DataNotFound);
        }
    }
}
