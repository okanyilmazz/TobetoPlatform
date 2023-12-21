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
    public class EducationProgramProgrammingLanguageBusinessRules : BaseBusinessRules
    {
        private readonly IEducationProgramProgrammingLanguageDal _educationProgramLanguageProgrammingDal;

        public EducationProgramProgrammingLanguageBusinessRules(IEducationProgramProgrammingLanguageDal educationProgramProgrammingLanguageDal)
        {
            _educationProgramLanguageProgrammingDal = educationProgramProgrammingLanguageDal;
        }
        public async Task IsExistsEducationProgramProgrammingLanguage(Guid educationProgramProgrammingLanguageId)
        {
            var result = await _educationProgramLanguageProgrammingDal.GetListAsync(
               predicate: e => e.Id == educationProgramProgrammingLanguageId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
