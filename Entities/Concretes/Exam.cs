using Core.Entities;

namespace Entities.Concretes;


public class Exam : Entity<Guid>
{
    public Guid QuestionTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<QuestionType> QuestionTypes { get; set; }
    public ICollection<OccupationClass> OccupationClasses { get; set; }
}