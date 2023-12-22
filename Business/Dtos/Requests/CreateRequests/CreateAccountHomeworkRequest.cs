using Entities.Concretes;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAccountHomeworkRequest
    {
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}
