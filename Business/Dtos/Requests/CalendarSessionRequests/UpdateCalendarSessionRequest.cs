namespace Business.Dtos.Requests.CalendarSessionRequests
{
    public class UpdateCalendarSessionRequest
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
    }
}