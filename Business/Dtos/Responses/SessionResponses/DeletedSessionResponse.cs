namespace Business.Dtos.Responses.SessionResponses
{
    public class DeletedSessionResponse
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecordPath { get; set; }
    }
}