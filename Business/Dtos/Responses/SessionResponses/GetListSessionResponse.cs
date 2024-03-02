namespace Business.Dtos.Responses.SessionResponses;

public class GetListSessionResponse
{
    public Guid Id { get; set; }
    public string LessonName { get; set; }
    public DateTime StartDate { get; set; }
    public string AccountName{ get; set; }
    public DateTime EndDate { get; set; }
    public string RecordPath { get; set; }
    public string OccupationClassName { get; set; }
}
