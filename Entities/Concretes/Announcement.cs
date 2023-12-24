using Core.Entities;

namespace Entities.Concretes;

public class Announcement : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AnnouncementDate { get; set; }

    public virtual ICollection<AnnouncementProject>? AnnouncementProjects { get; set; }
}
