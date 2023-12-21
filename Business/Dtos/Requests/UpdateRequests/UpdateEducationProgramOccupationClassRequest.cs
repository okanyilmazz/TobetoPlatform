namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateEducationProgramOccupationClassRequest
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}