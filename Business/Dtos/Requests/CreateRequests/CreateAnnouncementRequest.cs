using Entities.Concretes;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAnnouncementRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }
    }
}