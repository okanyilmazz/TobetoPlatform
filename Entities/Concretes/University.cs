using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class University : Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<AccountUniversity>? AccountUniversities { get; set; }
    }
}
