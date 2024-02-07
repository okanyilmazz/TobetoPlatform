using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AssesmentTestOccupationClass : Entity<Guid>
    {
        public Guid AssesmentTestId { get; set; }
        public Guid OccupationClassId { get; set; }

        public AssesmentTest AssesmentTest { get; set; }
        public OccupationClass OccupationClass { get; set; }
    }
}
