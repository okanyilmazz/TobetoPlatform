using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class QuestionAssesmentTest : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid CategoryName { get; set; }
        public string Description { get; set; }
        public string PointOne { get; set; }
        public string PointTwo { get; set; }
        public string PointThree { get; set; }
        public string PointFour { get; set; }
        public string PointFive { get; set; }

        public ICollection<AssesmentTestQuestion>? AssesmentQuestions { get; set; }
    }
}
