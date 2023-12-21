namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateAnnouncementProjectRequest
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}