namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountOccupationClassRequest
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}