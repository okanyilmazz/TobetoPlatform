namespace Business.Dtos.Requests.CompetenceQuestionRequests;

public class UpdateCompetenceQuestionRequest
{
    public Guid Id { get; set; }
    public Guid CompetenceId { get; set; }
    public string Question { get; set; }
    public int MaxOption { get; set; }
}
