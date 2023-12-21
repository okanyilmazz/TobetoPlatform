using Core.Entities;

namespace Entities.Concretes;

public class ProgrammingLanguage : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<EducationProgram>? EducationPrograms { get; set; }
}