namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAccountSessionResponse
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}