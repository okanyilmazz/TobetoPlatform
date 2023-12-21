using Business.Dtos.Requests.DeleteRequests;

namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateAccountLessonRequest
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid AccountId { get; set; }
    }
}
