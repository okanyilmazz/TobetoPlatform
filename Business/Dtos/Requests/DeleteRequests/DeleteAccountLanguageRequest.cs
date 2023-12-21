namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountLanguageRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
    }
}