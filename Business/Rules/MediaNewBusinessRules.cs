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
    public class MediaNewBusinessRules : BaseBusinessRules
    {
        IMediaNewDal _mediaNewDal;

        public MediaNewBusinessRules(IMediaNewDal mediaNewDal)
        {
            _mediaNewDal = mediaNewDal;
        }

        public async Task IsExistsMediaNew(Guid mediaNewId)
        {
            var result = await _mediaNewDal.GetListAsync(m => m.Id == mediaNewId, enableTracking: false);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

    }
}
