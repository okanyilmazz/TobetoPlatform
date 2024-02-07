using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AssesmentTestAnswer : Entity<Guid>
    {
        public Guid AccountId { get; set; }
        public Guid AssesmentTestId { get; set; }
        public Guid QuestionAssesmentTestId { get; set; }
        public string GivenAnswer { get; set; }

        public Account Account { get; set; }
        public AssesmentTest AssesmentTest { get; set; }
        public QuestionAssesmentTest QuestionAssesmentTest { get; set; }
    }
}
