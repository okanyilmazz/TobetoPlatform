using Core.Entities;

namespace Entities.Concretes;

public class AccountUniversity : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid DegreeTypeId { get; set; }
    public Guid UniversityId { get; set; }
    public Guid UniversityDepartmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsEducationActive { get; set; }
}
