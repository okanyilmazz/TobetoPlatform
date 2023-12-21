using Core.Entities;

namespace Entities.Concretes;

public class AccountOccupationClass : Entity<Guid>
{
    public Guid OccupationClassId { get; set; }
    public Guid AccountId { get; set; }
}
