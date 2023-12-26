using System;
namespace Business.Dtos.Requests.DeleteRequests;

public class DeleteExamQuestionRequest
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

