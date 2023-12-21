using Core.Entities;

namespace Entities.Concretes;

public class LessonSubject : Entity<Guid>
{
    public string Name { get; set; }
}
