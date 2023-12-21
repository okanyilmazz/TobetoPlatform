namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAccountSocialMediaResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
