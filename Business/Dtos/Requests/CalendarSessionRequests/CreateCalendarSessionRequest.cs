using Entities.Concretes;

namespace Business.Dtos.Requests.CalendarSessionRequests
{
    public class CreateCalendarSessionRequest
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
    }
}