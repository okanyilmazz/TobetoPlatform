namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAnnouncementProjectRequest
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}