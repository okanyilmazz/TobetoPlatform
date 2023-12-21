namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteUniversityDepartmentRequest
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}