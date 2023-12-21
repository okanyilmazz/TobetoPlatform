using Core.Entities;

namespace Entities.Concretes;

public class Project : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Announcement>? Announcements { get; set; }
}