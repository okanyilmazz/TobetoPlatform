using Entities.Concretes;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAnnouncementResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }

        public ICollection<GetListProjectResponse> Projects { get; set; }
    }
}