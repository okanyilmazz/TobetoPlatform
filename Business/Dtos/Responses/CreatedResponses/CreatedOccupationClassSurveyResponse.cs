namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedOccupationClassSurveyResponse
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}