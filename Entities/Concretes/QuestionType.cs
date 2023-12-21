using Core.Entities;

namespace Entities.Concretes;

public class QuestionType : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<Exam> Exams { get; set; }
}