using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Rules
{
	public class OccupationClassSurveyBusinessRules:BaseBusinessRules
	{
        private readonly IOccupationClassSurveyDal _occupationClassSurveyDal;

        public OccupationClassSurveyBusinessRules(IOccupationClassSurveyDal occupationClassSurveyDal)
        {
            _occupationClassSurveyDal = occupationClassSurveyDal;
        }

        public async Task IsExistsOccupationClassSurvey(Guid occupationClassSurveyId)
        {
            var result = await _occupationClassSurveyDal.GetListAsync(
                predicate: o => o.Id == occupationClassSurveyId
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

