namespace Business.Dtos.Requests.LessonModuleRequests
{
    public class UpdateLessonModuleRequest
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid ModuleId { get; set; }
    }
}