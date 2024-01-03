using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UniversityBusinessRules : BaseBusinessRules
    {
        private readonly IUniversityDal _universityDal;

        public UniversityBusinessRules(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }

        public async Task IsExistsUniversity(Guid universityId)
        {
            var result = await _universityDal.GetListAsync(
                predicate: u => u.Id == universityId
              );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
