namespace Business.Dtos.Requests.LessonModuleRequests
{
    public class CreateLessonModuleRequest
    {
        public Guid LessonId { get; set; }
        public Guid ModuleId { get; set; }
    }
}