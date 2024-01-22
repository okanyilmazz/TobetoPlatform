namespace Business.Dtos.Requests.EducationProgramRequests;

public class CreateEducationProgramRequest
{
    public string Name { get; set; }
    public string ThumbnailPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }

    public Guid EducationProgramLevelId { get; set; }
}
