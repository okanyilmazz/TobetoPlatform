namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAccountLessonResponse
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid AccountId { get; set; }
    }
}