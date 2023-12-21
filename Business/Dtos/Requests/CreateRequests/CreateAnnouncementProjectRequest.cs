namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAnnouncementProjectRequest
    {
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}