using Core.Entities;

namespace Business.Dtos.Requests.InstructorRequests
{
    public class UpdateInstructorRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}