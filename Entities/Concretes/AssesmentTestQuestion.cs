using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AssesmentTestQuestion : Entity<Guid>
    {
        public Guid QuestionForAssesmentTestId { get; set; }
        public Guid AssesmentTestId { get; set; }

        public QuestionAssesmentTest QuestionForAssesmentTest { get; set; }
        public AssesmentTest AssesmentTest { get; set; }
    }
}
