namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateExamQuestionTypeRequest
    {
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}