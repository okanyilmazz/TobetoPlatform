using System;
using Business.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Rules
{
	public class EducationProgramOccupationClassBusinessRules
	{
        private readonly IEducationProgramOccupationClassDal _educationProgramOccupationClassDal;

        public EducationProgramOccupationClassBusinessRules(IEducationProgramOccupationClassDal educationProgramOccupationClassDal)
        {
            _educationProgramOccupationClassDal = educationProgramOccupationClassDal;
        }

        public async Task IsExistsEducationProgramOccupationClass(Guid educationProgramOccupationClassId)
        {
            var result = await _educationProgramOccupationClassDal.GetListAsync(
                predicate: e => e.Id == educationProgramOccupationClassId
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

