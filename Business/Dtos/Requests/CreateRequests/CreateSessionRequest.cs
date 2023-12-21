using Entities.Concretes;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateSessionRequest
    {
        public Guid OccupationClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecordPath { get; set; }
    }
}