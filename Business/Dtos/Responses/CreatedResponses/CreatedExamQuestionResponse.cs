using System;
namespace Business.Dtos.Responses.CreatedResponses;

public class CreatedExamQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

