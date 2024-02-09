using Core.Entities;

namespace Entities.Concretes;

public class Homework : Entity<Guid>
{
    public Guid OccupationClassId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public DateTime Deadline { get; set; }

    public OccupationClass OccupationClass { get; set; }
    public virtual ICollection<AccountHomework>? AccountHomeworks { get; set; }
}
