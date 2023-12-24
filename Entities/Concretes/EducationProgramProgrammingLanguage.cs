using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramProgrammingLanguage : Entity<Guid>
{
    public Guid EducationProgramId { get; set; }
    public Guid ProgrammingLanguageId { get; set; }
    public EducationProgram? EducationPrograms { get; set; }
    public ProgrammingLanguage? ProgrammingLanguages { get; set; }
}
