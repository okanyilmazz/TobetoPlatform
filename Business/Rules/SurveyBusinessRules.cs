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
    public class SurveyBusinessRules : BaseBusinessRules
    {
        private readonly ISurveyDal _surveyDal;

        public SurveyBusinessRules(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }
        public async Task IsExistsSurvey(Guid surveyId)
        {
            var result = await _surveyDal.GetListAsync(
                predicate: s => s.Id == surveyId, enableTracking: false);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
