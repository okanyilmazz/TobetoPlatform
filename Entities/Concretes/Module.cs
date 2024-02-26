using Core.DataAccess.Dynamic;
using Core.Entities;

namespace Entities.Concretes;

public class Module : Entity<Guid>
{
    public Guid? ParentId { get; set; }
    public string Name { get; set; }

    public Module? Parent { get; set; }
    public virtual ICollection<Module>? Children { get; set; }
    public virtual ICollection<EducationProgramModule> EducationProgramModules { get; set; }
    public virtual ICollection<LessonModule>? LessonModules { get; set; }
}