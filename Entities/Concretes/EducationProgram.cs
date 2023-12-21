using Core.Entities;

namespace Entities.Concretes;

public class EducationProgram : Entity<Guid>
{
    public string Name { get; set; }
    public Guid EducationProgramLevelId { get; set; }

    public virtual ICollection<Lesson>? Lessons { get; set; }
    public virtual ICollection<OccupationClass>? OccupationClasses { get; set; } 
    public virtual ICollection<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
}