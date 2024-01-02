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
    public class EducationProgramProgrammingLanguageBusinessRules : BaseBusinessRules
    {
        private readonly IEducationProgramProgrammingLanguageDal _educationProgramProgrammingLanguageDal;

        public EducationProgramProgrammingLanguageBusinessRules(IEducationProgramProgrammingLanguageDal educationProgramProgrammingLanguageDal)
        {
            _educationProgramProgrammingLanguageDal = educationProgramProgrammingLanguageDal;
        }
        public async Task IsExistsEducationProgramProgrammingLanguage(Guid educationProgramProgrammingLanguageId)
        {
            var result = await _educationProgramProgrammingLanguageDal.GetAsync(
                predicate: e => e.Id == educationProgramProgrammingLanguageId, enableTracking: false
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
