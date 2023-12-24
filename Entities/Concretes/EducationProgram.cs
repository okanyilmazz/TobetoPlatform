using Core.Entities;

namespace Entities.Concretes;

public class EducationProgram : Entity<Guid>
{
    public string Name { get; set; }
    public Guid EducationProgramLevelId { get; set; }

    public EducationProgramLevel EducationProgramLevel { get; set; }
    public virtual ICollection<EducationProgramLesson>? EducationProgramLessons { get; set; }
    public virtual ICollection<EducationProgramOccupationClass>? EducationProgramOccupationClasses { get; set; } 
    public virtual ICollection<EducationProgramProgrammingLanguage>? EducationProgramProgrammingLanguages { get; set; }
}