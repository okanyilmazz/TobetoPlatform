namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAnnouncementProjectResponse
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}