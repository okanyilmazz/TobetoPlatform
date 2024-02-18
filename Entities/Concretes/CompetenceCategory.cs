using Core.Entities;

namespace Entities.Concretes;

public class CompetenceCategory : Entity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CompetenceQuestion>? CompetenceQuestions { get; set; }

}