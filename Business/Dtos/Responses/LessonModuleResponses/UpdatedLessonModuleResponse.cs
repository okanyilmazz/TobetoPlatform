namespace Business.Dtos.Responses.LessonModuleResponses
{
    public class UpdatedLessonModuleResponse
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid ModuleId { get; set; }
    }
}