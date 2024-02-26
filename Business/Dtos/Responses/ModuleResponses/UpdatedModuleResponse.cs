namespace Business.Dtos.Responses.ModuleResponses;

public class UpdatedModuleResponse

{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
