namespace Business.Dtos.Responses.CompetenceQuestionResponses;

public class CreatedCompetenceQuestionResponse
{
    public Guid Id { get; set; }
    public Guid CompetenceId { get; set; }
    public string Question { get; set; }
    public int MaxOption { get; set; }
}
