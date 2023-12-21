using Core.Entities;

namespace Entities.Concretes;

public class Survey : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }

    public ICollection<OccupationClass>? OccupationClasses { get; set; }
}