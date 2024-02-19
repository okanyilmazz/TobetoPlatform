namespace Business.Dtos.Requests.CompetenceQuestionRequests;

public class CreateCompetenceQuestionRequest
{
    public Guid CompetenceId { get; set; }
    public string Question { get; set; }
    public int MaxOption { get; set; }
}
