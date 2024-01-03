using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class LanguageLevelBusinessRules: BaseBusinessRules
    {
        private readonly ILanguageLevelDal _languageLevelDal;

        public LanguageLevelBusinessRules(ILanguageLevelDal languageLevelDal)
        {
            _languageLevelDal = languageLevelDal;
        }

        public async Task IsExistsLanguageLevel(Guid languageLevelId)
        {
            var result = await _languageLevelDal.GetListAsync(
                predicate: l => l.Id == languageLevelId, enableTracking: false
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
