using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.BusinessRules
{
    public class CalenderSessionBusinessRules : BaseBusinessRules
    {
        private readonly ICalendarSessionDal _calendarSessionDal;

        public CalenderSessionBusinessRules(ICalendarSessionDal calendarSessionDal)
        {
            calendarSessionDal = calendarSessionDal;
        }

        public async Task IsExistsCalendarSession(Guid calendarSessionId)
        {
            var result = await _calendarSessionDal.GetAsync(
                predicate: b => b.Id == calendarSessionId,
                enableTracking: false);

            if (result == null)
            {
                throw new BusinessException(BusinessMessages.DataNotFound);
            }
        }
    }
}
