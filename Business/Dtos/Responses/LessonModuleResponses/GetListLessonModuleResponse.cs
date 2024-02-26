using Business.Dtos.Responses.LessonResponses;
using Business.Dtos.Responses.ModuleResponses;

namespace Business.Dtos.Responses.LessonModuleResponses
{
    public class GetListLessonModuleResponse
    {
        public Guid Id { get; set; }

        public ICollection<GetListModuleResponse> Modules { get; set; }
        public ICollection<GetListLessonResponse> Lessons { get; set; }
    }
}