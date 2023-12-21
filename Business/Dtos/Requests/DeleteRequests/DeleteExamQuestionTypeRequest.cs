namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteExamQuestionTypeRequest
    {
        public Guid Id { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}