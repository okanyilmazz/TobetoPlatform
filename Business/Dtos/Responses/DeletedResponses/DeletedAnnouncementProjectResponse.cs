namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAnnouncementProjectResponse
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}