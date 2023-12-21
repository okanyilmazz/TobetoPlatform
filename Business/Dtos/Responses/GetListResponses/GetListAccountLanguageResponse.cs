namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
    }
}