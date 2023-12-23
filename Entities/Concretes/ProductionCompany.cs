using Core.Entities;

namespace Entities.Concretes;

public class ProductionCompany : Entity<Guid>
{
    public string Name { get; set; }

    public ICollection<Lesson>? Lessons { get; set; }
}