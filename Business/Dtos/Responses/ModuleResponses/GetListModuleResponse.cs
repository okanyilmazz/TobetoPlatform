using Business.Dtos.Responses.LessonResponses;
using Entities.Concretes;

namespace Business.Dtos.Responses.ModuleResponses;

public class GetListModuleResponse
{
    public Guid? Id { get; set; }
    public string Name { get; set; }

    public ICollection<GetListModuleResponse> Children { get; set; }
    public ICollection<GetListLessonResponse> Lessons { get; set; }
}
