namespace Business.Dtos.Responses.UpdatedResponses
{
    public class UpdatedAccountHomeworkeResponse
    {
        public Guid Id { get; set; }
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}