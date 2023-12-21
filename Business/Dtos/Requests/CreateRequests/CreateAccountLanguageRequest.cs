namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateAccountLanguageRequest
    {
        public Guid AccountId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
    }
}