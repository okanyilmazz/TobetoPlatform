namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAccountSocialMediaResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
