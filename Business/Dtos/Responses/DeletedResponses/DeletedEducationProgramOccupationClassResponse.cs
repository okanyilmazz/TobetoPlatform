namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedEducationProgramOccupationClassResponse
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}