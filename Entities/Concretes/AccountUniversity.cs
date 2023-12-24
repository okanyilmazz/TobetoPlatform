using Core.Entities;
using Microsoft.Identity.Client;

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


    public Account? Accounts { get; set; }
    public DegreeType? DegreeTypes { get; set; }
    public University? Universities { get; set; }
    public UniversityDepartment? UniversityDepartments { get; set; }
}
