namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateEducationProgramProgrammingLanguageRequest
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
    }
}