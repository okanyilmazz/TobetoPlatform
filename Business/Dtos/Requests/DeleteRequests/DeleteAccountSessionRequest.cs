namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountSessionRequest
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}