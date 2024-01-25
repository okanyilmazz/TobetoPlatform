namespace Business.Dtos.Responses.AccountUniversityResponses;

public class GetListAccountUniversityResponse
{
    public Guid Id { get; set; }
    public string AccountName { get; set; }
    public string DegreeTypeName { get; set; }
    public string UniversityName { get; set; }
    public string UniversityDepartmentName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsEducationActive { get; set; }
}
