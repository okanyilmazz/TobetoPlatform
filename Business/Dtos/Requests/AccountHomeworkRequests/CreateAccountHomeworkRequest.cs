using Entities.Concretes;

namespace Business.Dtos.Requests.AccountHomeworkRequests
{
    public class CreateAccountHomeworkRequest
    {
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}
