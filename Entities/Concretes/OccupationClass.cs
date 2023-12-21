using Core.Entities;

namespace Entities.Concretes;

public class OccupationClass : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Homework>? Homeworks { get; set; }
    public virtual ICollection<Session>? Sessions { get; set; }
    public virtual ICollection<EducationProgram>? EducationPrograms { get; set; }
    public virtual ICollection<Exam>? Exams { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<Survey>? Surveys { get; set; }
}