using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Rules
{
	public class EducationProgramOccupationClassBusinessRules : BaseBusinessRules
    {
        private readonly IEducationProgramOccupationClassDal _educationProgramOccupationClassDal;

        public EducationProgramOccupationClassBusinessRules(IEducationProgramOccupationClassDal educationProgramOccupationClassDal)
        {
            _educationProgramOccupationClassDal = educationProgramOccupationClassDal;
        }

        public async Task IsExistsEducationProgramOccupationClass(Guid educationProgramOccupationClassId)
        {
            var result = await _educationProgramOccupationClassDal.GetAsync(
                predicate: e => e.Id == educationProgramOccupationClassId, enableTracking: false
                );
            if (result==null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

