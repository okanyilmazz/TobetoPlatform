namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteAccountSocialMediaRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
