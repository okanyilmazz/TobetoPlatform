namespace Business.Dtos.Responses.UpdatedResponses
{
    public class UpdatedAccountSocialMediaResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
