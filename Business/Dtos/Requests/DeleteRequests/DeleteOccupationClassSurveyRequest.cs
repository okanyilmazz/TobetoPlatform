namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteOccupationClassSurveyRequest
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}