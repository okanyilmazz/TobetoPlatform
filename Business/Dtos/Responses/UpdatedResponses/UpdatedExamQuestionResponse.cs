using System;
namespace Business.Dtos.Responses.UpdatedResponses;

public class UpdatedExamQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

