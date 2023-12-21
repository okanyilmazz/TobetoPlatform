using Entities.Concretes;

namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAnnouncementResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }

    }
}