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
    public class SkillBusinessRules : BaseBusinessRules
    {
        private readonly ISkillDal _skillDal;

        public SkillBusinessRules(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public async Task IsExistsSkill(Guid skillId)
        {

            var result = await _skillDal.GetAsync(predicate: s => s.Id == skillId, enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
