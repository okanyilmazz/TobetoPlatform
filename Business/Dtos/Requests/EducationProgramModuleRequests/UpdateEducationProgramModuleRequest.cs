namespace Business.Dtos.Requests.EducationProgramModuleRequests;

public class UpdateEducationProgramModuleRequest
{
    public Guid Id { get; set; }
    public Guid EducationProgramId { get; set; }
    public Guid ModuleId { get; set; }
}
