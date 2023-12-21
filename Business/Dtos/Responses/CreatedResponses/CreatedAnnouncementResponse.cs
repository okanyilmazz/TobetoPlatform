using Entities.Concretes;

namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAnnouncementResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}