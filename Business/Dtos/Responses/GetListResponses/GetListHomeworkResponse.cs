namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListHomeworkResponse
    {
        public Guid Id { get; set; }
        public Guid OccupationClassName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime Deadline { get; set; }
    }
}