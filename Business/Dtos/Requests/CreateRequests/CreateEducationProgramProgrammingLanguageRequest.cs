namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateEducationProgramProgrammingLanguageRequest
    {
        public Guid EducationProgramId { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
    }
}