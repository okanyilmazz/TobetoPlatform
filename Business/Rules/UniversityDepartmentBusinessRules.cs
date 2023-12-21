using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UniversityDepartmentBusinessRules : BaseBusinessRules
    {
        private readonly IUniversityDepartmentDal _universityDepartmentDal;

        public UniversityDepartmentBusinessRules(IUniversityDepartmentDal universityDepartmentDal)
        {
            _universityDepartmentDal = universityDepartmentDal;
        }

        public async Task IsExistsUniversityDepartment(Guid universityDepartmentId)
        {
            var result = await _universityDepartmentDal.GetListAsync(
                predicate: ud => ud.Id == universityDepartmentId
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }

        }

    }


}
