using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AssesmentTestResult
    {
        public Guid AccountId { get; set; }
        public Guid AssesmentTestId { get; set; }
        public int PointCount { get; set; }
        public int Result { get; set; }

        public Account Account { get; set; }
        public AssesmentTest AssesmentTest { get; set; }
    }
}
