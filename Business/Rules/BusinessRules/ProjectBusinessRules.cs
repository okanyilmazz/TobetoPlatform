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
    public class ProjectBusinessRules : BaseBusinessRules
    {
        IProjectDal _projectDal;

        public ProjectBusinessRules(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public async Task IsExistsProject(Guid projectId)
        {
            var result = await _projectDal.GetAsync(
                predicate: a => a.Id == projectId,
                enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
