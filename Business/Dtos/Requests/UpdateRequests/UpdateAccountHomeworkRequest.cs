namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateAccountHomeworkRequest
    {
        public Guid Id { get; set; }
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}