namespace Business.Dtos.Responses.ModuleResponses;

public class CreatedModuleResponse
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
