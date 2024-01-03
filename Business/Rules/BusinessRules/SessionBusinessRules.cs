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
    public class SessionBusinessRules : BaseBusinessRules
    {
        private readonly ISessionDal _sessionDal;

        public SessionBusinessRules(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public async Task IsExistsSession(Guid sessionId)
        {
            var result = await _sessionDal.GetAsync(
                predicate: s => s.Id == sessionId, enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
