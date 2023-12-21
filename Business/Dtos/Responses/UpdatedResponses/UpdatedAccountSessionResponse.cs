namespace Business.Dtos.Responses.UpdatedResponses
{
    public class UpdatedAccountSessionResponse
    {
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}