using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramLevel : Entity<Guid>
{
    public string Name { get; set; }
}
