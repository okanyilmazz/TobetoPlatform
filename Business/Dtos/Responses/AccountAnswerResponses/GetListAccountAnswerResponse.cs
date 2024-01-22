namespace Business.Dtos.Responses.AccountAnswerResponses;

public class GetListAccountAnswerResponse
{
    public Guid Id { get; set; }
    public string AccountName { get; set; }
    public string ExamName { get; set; }
    public string QuestionName { get; set; }
    public string GivenAnswer { get; set; }
}
