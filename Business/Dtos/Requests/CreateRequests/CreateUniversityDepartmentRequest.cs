namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateUniversityDepartmentRequest
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}