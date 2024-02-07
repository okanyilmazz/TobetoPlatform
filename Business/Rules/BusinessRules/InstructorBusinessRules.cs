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
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorDal _instructorDal;

        public InstructorBusinessRules(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public async Task IsExistsInstructor(Guid instructorId)
        {
            var result = await _instructorDal.GetAsync(
                predicate: i => i.Id == instructorId,
                enableTracking: false);

            if (result == null)
            {
                throw new BusinessException(BusinessMessages.DataNotFound);
            }
        }
    }
}
