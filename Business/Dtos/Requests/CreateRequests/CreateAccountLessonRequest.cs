namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAccountLessonRequest
    {
        public Guid LessonId { get; set; }
        public Guid AccountId { get; set; }
    }
}