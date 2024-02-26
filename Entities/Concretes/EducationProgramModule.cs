using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramModule : Entity<Guid>
{
    public Guid EducationProgramId { get; set; }
    public Guid ModuleId { get; set; }

    public EducationProgram EducationProgram { get; set; }
    public Module Module { get; set; }
}
