using Entities.Concretes;

namespace Business.Dtos.Requests.CompetenceResultRequests;

public class CreateCompetenceResultRequest
{
    public Guid CompetenceId { get; set; }
    public Guid AccountId { get; set; }
    public double Point { get; set; }

}
