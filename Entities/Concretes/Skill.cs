using Core.Entities;

namespace Entities.Concretes;

public class Skill : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Account>? Accounts { get; set; }
}
