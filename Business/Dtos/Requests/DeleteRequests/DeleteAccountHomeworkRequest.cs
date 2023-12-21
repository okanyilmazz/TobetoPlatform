namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountHomeworkRequest
    {
        public Guid Id { get; set; }
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}