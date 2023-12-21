namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAccountLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
    }
}