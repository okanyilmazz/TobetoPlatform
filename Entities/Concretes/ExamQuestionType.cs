using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ExamQuestionType : Entity<Guid>
    {
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }

        public Exam Exam { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
