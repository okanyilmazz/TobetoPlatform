using Core.Entities;

namespace Entities.Concretes;

public class AccountLesson : Entity<Guid>
{
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }
}
