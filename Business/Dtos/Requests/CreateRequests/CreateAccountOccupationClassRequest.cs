namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAccountOccupationClassRequest
    {
        public Guid OccupationClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}