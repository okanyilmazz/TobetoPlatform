namespace Business.Dtos.Responses.CompetenceResultResponses;

public class DeletedCompetenceResultResponse
{
    public Guid Id { get; set; }
    public Guid CompetenceId { get; set; }
    public Guid AccountId { get; set; }
    public double Point { get; set; }
}
