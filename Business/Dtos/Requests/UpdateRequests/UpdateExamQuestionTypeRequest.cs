namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateExamQuestionTypeRequest
    {
        public Guid Id { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}