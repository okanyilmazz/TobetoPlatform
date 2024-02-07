using Core.Entities;
using Entities.Concretes;

namespace Business.Dtos.Requests.InstructorRequests
{
    public class CreateInstructorRequest
    {
        public Guid UserId { get; set; }
    }
}