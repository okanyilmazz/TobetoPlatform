namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateAccountOccupationClassRequest
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}