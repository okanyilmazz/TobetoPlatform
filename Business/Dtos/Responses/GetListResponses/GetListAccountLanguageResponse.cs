namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountLanguageResponse
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevelName { get; set; }
    }
}