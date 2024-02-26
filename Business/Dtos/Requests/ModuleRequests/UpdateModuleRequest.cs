namespace Business.Dtos.Requests.ModuleRequests;

public class UpdateModuleRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
