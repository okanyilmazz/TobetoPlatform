namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAccountSessionResponse
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}