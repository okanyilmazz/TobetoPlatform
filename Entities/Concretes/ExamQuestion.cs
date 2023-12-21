using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ExamQuestion : Entity<Guid>
    {
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }
}
