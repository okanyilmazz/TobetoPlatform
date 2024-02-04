namespace Business.Dtos.Responses.CalendarSessionResponses
{
    public class GetListCalendarSessionResponse
    {
        public Guid SessionId { get; set; }
        public string OccupationClassName { get; set; }//Session
        public DateTime StartDate { get; set; }//Session
        public DateTime EndDate { get; set; }//Session
        public Guid UserOperationClaimId { get; set; } //Uoc
        public string UserFirstName { get; set; }//Uoc
        public string UserLastName { get; set; } //Uoc
    }
}