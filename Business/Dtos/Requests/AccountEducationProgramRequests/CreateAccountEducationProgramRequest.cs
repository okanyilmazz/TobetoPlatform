namespace Business.Dtos.Requests.AccountEducationProgramRequests;

public class CreateAccountEducationProgramRequest
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public int StatusPercent { get; set; }
}
