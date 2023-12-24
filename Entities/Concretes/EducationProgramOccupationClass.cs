using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class EducationProgramOccupationClass : Entity<Guid>
    {
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }

        public EducationProgram? EducationProgram { get; set; }
        public OccupationClass? OccupationClass { get; set; }
    }
}
