namespace Business.Dtos.Responses.ModuleResponses;

public class DeletedModuleResponse
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
