using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Homework : Entity<Guid>
    {
        public Guid OccupationClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime Deadline { get; set; }

        public OccupationClass OccupationClass { get; set; }
        public virtual ICollection<AccountHomework>? AccountHomeworks { get; set; }
    }
}
