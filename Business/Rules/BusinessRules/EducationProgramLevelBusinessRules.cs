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
    public class EducationProgramLevelBusinessRules : BaseBusinessRules
    {
        private readonly IEducationProgramLevelDal _educationProgramLevelDal;

        public EducationProgramLevelBusinessRules(IEducationProgramLevelDal educationProgramLevelDal)
        {
            _educationProgramLevelDal = educationProgramLevelDal;
        }

        public async Task IsExistsEducationProgramLevel(Guid educationProgramLevelId)
        {
            var result = await _educationProgramLevelDal.GetListAsync(
                predicate: q => q.Id == educationProgramLevelId
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
