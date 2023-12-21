namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteEducationProgramProgrammingLanguageRequest
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
    }
}