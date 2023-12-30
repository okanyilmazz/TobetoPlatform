namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountSessionResponse
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public string AccountName { get; set; }
        public bool Status { get; set; }
    }
}