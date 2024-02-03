namespace Business.Dtos.Responses.BlogResponses
{
    public class GetListBlogResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string ThumbnailPath { get; set; }
    }
}