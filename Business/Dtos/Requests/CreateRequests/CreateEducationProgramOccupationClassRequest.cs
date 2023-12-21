namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateEducationProgramOccupationClassRequest
    {
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}