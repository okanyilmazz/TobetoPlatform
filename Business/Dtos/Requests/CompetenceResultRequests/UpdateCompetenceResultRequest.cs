namespace Business.Dtos.Requests.CompetenceResultRequests;

public class UpdateCompetenceResultRequest
{
    public Guid Id { get; set; }
    public Guid CompetenceId { get; set; }
    public Guid AccountId { get; set; }
    public double Point { get; set; }
}
