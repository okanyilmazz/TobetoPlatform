namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountLessonRequest
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid AccountId { get; set; }
    }
}