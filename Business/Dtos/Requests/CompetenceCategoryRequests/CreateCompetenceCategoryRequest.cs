using Entities.Concretes;

namespace Business.Dtos.Requests.CompetenceRequests;

public class CreateCompetenceCategoryRequest
{
    public string Name { get; set; }
    public virtual ICollection<CompetenceQuestion>? CompetenceQuestions { get; set; }
}
