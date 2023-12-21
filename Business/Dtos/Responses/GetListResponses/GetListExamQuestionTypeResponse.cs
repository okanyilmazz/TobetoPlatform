namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListExamQuestionTypeResponse
    {
        public Guid Id { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}