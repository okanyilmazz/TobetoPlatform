namespace Business.Dtos.Responses.LessonModuleResponses
{
    public class CreatedLessonModuleResponse
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid ModuleId { get; set; }
    }
}