namespace Business.Dtos.Requests.ModuleRequests;

public class CreateModuleRequest
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
