namespace Core.Entities;

public class UserOperationClaim : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}
