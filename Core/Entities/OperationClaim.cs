namespace Core.Entities;

public class OperationClaim : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<UserOperationClaim> UserOperationClaim { get; set; }

} 