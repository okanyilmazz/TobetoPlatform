using System;
namespace Business.Dtos.Responses.GetListResponses;

public class GetListExamQuestionResponse
{
    public Guid Id { get; set; }
    public string QuestionName { get; set; }
    public string ExamName { get; set; }
}

