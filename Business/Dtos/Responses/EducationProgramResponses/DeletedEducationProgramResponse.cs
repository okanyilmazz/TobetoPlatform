namespace Business.Dtos.Responses.EducationProgramResponses;

public class DeletedEducationProgramResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ThumbnailPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }
    public Guid EducationProgramLevelId { get; set; }
}
