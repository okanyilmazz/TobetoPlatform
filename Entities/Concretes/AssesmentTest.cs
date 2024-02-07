using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AssesmentTest : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public int QuestionCount { get; set; }

        public virtual ICollection<AssesmentTestQuestion> AssesmentTestQuestions { get; set; }
        public virtual ICollection<AssesmentTestOccupationClass> AssesmentTestOccupationClasses { get; set; }
    }
}
