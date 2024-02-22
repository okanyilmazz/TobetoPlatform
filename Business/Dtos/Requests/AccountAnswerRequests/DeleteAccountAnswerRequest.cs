namespace Business.Dtos.Requests.AccountAnswerRequests;

public class DeleteAccountAnswerRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public Guid QuestionId { get; set; }
    public string GivenAnswer { get; set; }
}
