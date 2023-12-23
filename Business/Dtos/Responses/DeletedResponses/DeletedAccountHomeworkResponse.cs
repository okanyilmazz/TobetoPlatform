using Entities.Concretes;

namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAccountHomeworkResponse
    {
        public Guid Id { get; set; }
        public Guid HomeworkId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}