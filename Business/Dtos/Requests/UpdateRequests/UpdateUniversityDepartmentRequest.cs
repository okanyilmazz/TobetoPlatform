namespace Business.Dtos.Requests.UpdateRequests
{
    public class UpdateUniversityDepartmentRequest
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}