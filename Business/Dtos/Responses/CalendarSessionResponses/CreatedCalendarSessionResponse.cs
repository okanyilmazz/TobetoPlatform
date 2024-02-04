namespace Business.Dtos.Responses.CalendarSessionResponses
{
    public class CreatedCalendarSessionResponse
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
    }
}