using System;
namespace Business.Dtos.Responses.GetListResponses;

public class GetListExamQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

