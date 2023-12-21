using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AccountSkill : Entity<Guid>
    {
        public Guid SkillId { get; set; }
        public Guid AccountId { get; set; }
    }
}
