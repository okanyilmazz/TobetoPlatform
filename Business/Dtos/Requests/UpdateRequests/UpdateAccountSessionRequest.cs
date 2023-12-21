namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateAccountSessionRequest
    {
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}