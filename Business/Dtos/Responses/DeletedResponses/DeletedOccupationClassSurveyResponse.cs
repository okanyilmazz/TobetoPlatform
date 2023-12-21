namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedOccupationClassSurveyResponse
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}