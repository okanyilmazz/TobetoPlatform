namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedHomeworkResponse
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime Deadline { get; set; }
    }
}