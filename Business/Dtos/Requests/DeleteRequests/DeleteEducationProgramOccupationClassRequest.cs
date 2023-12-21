namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteEducationProgramOccupationClassRequest
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}