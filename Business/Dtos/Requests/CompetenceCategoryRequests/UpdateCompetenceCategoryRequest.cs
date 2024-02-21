using Entities.Concretes;

namespace Business.Dtos.Requests.CompetenceRequests;

public class UpdateCompetenceCategoryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CompetenceQuestion>? CompetenceQuestions { get; set; }
}
