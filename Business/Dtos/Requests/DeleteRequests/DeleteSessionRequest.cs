namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteSessionRequest
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecordPath { get; set; }
    }
}