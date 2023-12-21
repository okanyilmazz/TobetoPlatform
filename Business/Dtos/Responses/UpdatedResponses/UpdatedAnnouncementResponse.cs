using Entities.Concretes;

namespace Business.Dtos.Responses.UpdatedResponses
{
    public class UpdatedAnnouncementResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }

    }
}