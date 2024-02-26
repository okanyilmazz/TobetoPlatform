using Core.Entities;

namespace Entities.Concretes;

public class LessonModule : Entity<Guid>
{
    public Guid? LessonId { get; set; }
    public Guid? ModuleId { get; set; }

    public Lesson Lesson { get; set; }
    public Module Module { get; set; }
}
