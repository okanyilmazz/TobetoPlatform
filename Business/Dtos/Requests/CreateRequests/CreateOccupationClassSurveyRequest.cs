namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateOccupationClassSurveyRequest
    {
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}