using Core.Entities;

namespace Entities.Concretes;

public class CompetenceQuestion : Entity<Guid>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int MaxOption { get; set; }
    public Guid CompetenceCategoryId { get; set; }
    public CompetenceCategory CompetenceCategory { get; set; }

}
