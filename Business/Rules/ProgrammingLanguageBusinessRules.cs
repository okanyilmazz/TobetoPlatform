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
    public class ProgrammingLanguageBusinessRules : BaseBusinessRules
    {
        private readonly IProgrammingLanguageDal _programmingLanguageDal;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageDal programmingLanguageDal)
        {
            _programmingLanguageDal = programmingLanguageDal;
        }

        public async Task IsExistsProgrammingLanguage(Guid programmingLanguageId)
        {

            var result = await _programmingLanguageDal.GetListAsync(
                predicate: s => s.Id == programmingLanguageId
                 );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

